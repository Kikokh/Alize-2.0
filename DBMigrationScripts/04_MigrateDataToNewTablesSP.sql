DROP PROCEDURE IF EXISTS [dbo].[MigrateDataToNewTablesSP]

GO

CREATE PROCEDURE [dbo].[MigrateDataToNewTablesSP]
	@TablesToMigrate VARCHAR(MAX),
	@IsRelationshipTable BIT
AS

DECLARE @CurrentId SMALLINT = 1
DECLARE @Columns VARCHAR(MAX)
DECLARE @TableNm VARCHAR(100)
DECLARE @Cmd VARCHAR(MAX)
DECLARE @TruncCmd VARCHAR(200)
DECLARE @SpecialTables TABLE (TableNm VARCHAR(100))
DECLARE @JoinTable TABLE (RefTableNm VARCHAR(100), RefColumnNm VARCHAR(100), TableNm VARCHAR(100), ColumnNm VARCHAR(100), JoinCmd VARCHAR(MAX))
DECLARE @InsertColumns VARCHAR(MAX)
DECLARE @SelectColumns VARCHAR(MAX)

DECLARE @FKData TABLE(PKTABLE_QUALIFIER VARCHAR(100), PKTABLE_OWNER VARCHAR(100),
PKTABLE_NAME VARCHAR(100), PKCOLUMN_NAME VARCHAR(100), FKTABLE_QUALIFIER VARCHAR(100), 
FKTABLE_OWNER VARCHAR(100), FKTABLE_NAME VARCHAR(100), FKCOLUMN_NAME VARCHAR(100), 
KEY_SEQ	INT, UPDATE_RULE INT, DELETE_RULE INT, FK_NAME VARCHAR(100), 
PK_NAME VARCHAR(100), DEFERRABILITY INT)

INSERT INTO @SpecialTables
VALUES ('Users'), ('Roles'), ('Petitions')

-- Drop temp tables if they exist --

IF OBJECT_ID('tempdb..#TablesToCheck') IS NOT NULL DROP TABLE #TablesToCheck
IF OBJECT_ID('tempdb..#SpecialTablesToCheck') IS NOT NULL DROP TABLE #TablesToCheck
IF OBJECT_ID('tempdb..#FKRelationships') IS NOT NULL DROP TABLE #FKRelationships

SELECT IDENTITY(INT,1,1) AS Id, [Value]
INTO #TablesToCheck
FROM STRING_SPLIT(@TablesToMigrate, '|')
WHERE RTRIM(LTRIM([Value])) <> ''
AND [Value] NOT IN (SELECT TableNm FROM @SpecialTables)
ORDER BY 1

SELECT IDENTITY(INT,1,1) AS Id, [Value]
INTO #SpecialTablesToCheck
FROM STRING_SPLIT(@TablesToMigrate, '|')
WHERE RTRIM(LTRIM([Value])) <> ''
AND [Value] IN (SELECT TableNm FROM @SpecialTables)
ORDER BY 1

-- Main non-relationship tables migration --
IF @IsRelationshipTable = 0
BEGIN

	WHILE EXISTS(SELECT 1 FROM #TablesToCheck)
	BEGIN
		SET @TableNm = (SELECT Value FROM #TablesToCheck WHERE Id = @CurrentId)

		INSERT INTO @FKData
		EXEC sp_fkeys @fktable_name=@TableNm

		IF EXISTS(SELECT 1 FROM @FKData)
		BEGIN

			INSERT INTO @JoinTable
			SELECT PKTABLE_NAME+'_NEW', PKCOLUMN_NAME,
			FKTABLE_NAME, FKCOLUMN_NAME,
			' JOIN dbo.['+PKTABLE_NAME+'_NEW] (NOLOCK) 
			ON dbo.['+PKTABLE_NAME+'_NEW].'+PKCOLUMN_NAME+'_OLD = A.'+FKCOLUMN_NAME [JoinCmd]
			FROM @FKData
			
			SET @InsertColumns =
						(SELECT STRING_AGG(A.[Column], ', ')
						FROM
							(SELECT CASE WHEN ac.name = 'Id' THEN 'Id_OLD' ELSE ac.name END [Column]
							FROM sys.all_objects ao
							JOIN sys.all_columns ac
							ON ao.object_id = ac.object_id
							WHERE ao.name = @TableNm
							AND ac.name NOT IN (SELECT ColumnNm FROM @JoinTable)
							  UNION ALL
							SELECT ColumnNm
							FROM @JoinTable) A)
			
			SET @SelectColumns =
						(SELECT STRING_AGG(A.[Column], ', ')
						FROM
							(SELECT 'A.'+ac.name [Column]
							FROM sys.all_objects ao
							JOIN sys.all_columns ac
							ON ao.object_id = ac.object_id
							WHERE ao.name = @TableNm
							AND ac.name NOT IN (SELECT ColumnNm FROM @JoinTable)
							  UNION ALL
							SELECT 'dbo.['+RefTableNm+'].'+RefColumnNm
							FROM @JoinTable) A) 

			SET @Cmd = (SELECT FORMATMESSAGE('INSERT INTO [%s_NEW](%s) SELECT %s FROM dbo.%s A %s',@TableNm,@InsertColumns,@SelectColumns,@TableNm, JoinCmd) FROM @JoinTable)
			EXEC (@Cmd)
			
		END

		IF NOT EXISTS(SELECT 1 FROM @FKData)
		BEGIN
			SET @Columns =
				(SELECT STRING_AGG(A.[Column], ', ')
				FROM
					(SELECT CASE WHEN ac.name = 'Id' THEN 'Id_OLD' ELSE ac.name END [Column]
					FROM sys.all_objects ao
					JOIN sys.all_columns ac
					ON ao.object_id = ac.object_id
					WHERE ao.name = @TableNm) A)

			SET @Cmd = (SELECT FORMATMESSAGE('INSERT INTO [%s_NEW](%s) SELECT * FROM %s',@TableNm,@Columns,@TableNm))
			EXEC (@Cmd)
		END

		DELETE FROM @JoinTable
		DELETE FROM @FKData

		DELETE FROM #TablesToCheck WHERE Id = @CurrentId
		SET @CurrentId = @CurrentId+1
	END
END

IF @IsRelationshipTable = 1
BEGIN

	DECLARE @RefTable1 VARCHAR(100)
	DECLARE @RefTable2 VARCHAR(100)
	DECLARE @RefTCol1 VARCHAR(100)
	DECLARE @RefTCol2 VARCHAR(100)
	DECLARE @RelTCol1 VARCHAR(100)
	DECLARE @RelTCol2 VARCHAR(100)
	
	WHILE EXISTS(SELECT 1 FROM #TablesToCheck)
	BEGIN
		SET @TableNm = (SELECT Value FROM #TablesToCheck WHERE Id = @CurrentId)

		SELECT  obj.name AS FK_NAME,
			sch.name AS [schema_name],
			tab1.name AS [table],
			col1.name AS [column],
			tab2.name AS [referenced_table],
			col2.name AS [referenced_column]
		INTO #FKRelationships
		FROM sys.foreign_key_columns fkc
		INNER JOIN sys.objects obj
			ON obj.object_id = fkc.constraint_object_id
		INNER JOIN sys.tables tab1
			ON tab1.object_id = fkc.parent_object_id
		INNER JOIN sys.schemas sch
			ON tab1.schema_id = sch.schema_id
		INNER JOIN sys.columns col1
			ON col1.column_id = parent_column_id
			AND col1.object_id = tab1.object_id
		INNER JOIN sys.tables tab2
			ON tab2.object_id = fkc.referenced_object_id
		INNER JOIN sys.columns col2
			ON col2.column_id = referenced_column_id
			AND col2.object_id = tab2.object_id
		WHERE tab1.name = @TableNm

		SET @RefTable1 = (SELECT TOP 1 referenced_table FROM #FKRelationships WHERE [table] = @TableNm)
		SET @RefTable2 = (SELECT TOP 1 referenced_table FROM #FKRelationships WHERE referenced_table <> @RefTable1 AND [table] = @TableNm)
		SET @RefTCol1 = (SELECT referenced_column FROM #FKRelationships WHERE [table] = @TableNm AND referenced_table = @RefTable1)
		SET @RefTCol2 = (SELECT referenced_column FROM #FKRelationships WHERE [table] = @TableNm AND referenced_table = @RefTable2)
		SET @RelTCol1 = (SELECT [column] FROM #FKRelationships WHERE [table] = @TableNm AND referenced_table = @RefTable1)
		SET @RelTCol2 = (SELECT [column] FROM #FKRelationships WHERE [table] = @TableNm AND referenced_table = @RefTable2)

		SET @Cmd =
			(SELECT FORMATMESSAGE(
			'INSERT INTO %s_NEW 
			SELECT RefT1.%s, RefT2.%s
			FROM %s RelT
			JOIN %s_NEW RefT1
			ON RelT.%s = RefT1.%s_OLD
			JOIN %s_NEW RefT2
			ON RelT.%s = RefT2.%s_OLD'
			, @TableNm
			, @RefTCol1, @RefTCol2, @TableNm
			, @RefTable1, @RelTCol1, @RefTCol1
			, @RefTable2, @RelTCol2, @RefTCol2))
		SET @TruncCmd = (SELECT FORMATMESSAGE('TRUNCATE TABLE [%s_NEW]',@TableNm))

		EXEC (@TruncCmd)
		EXEC (@Cmd)

		DELETE FROM #TablesToCheck WHERE Id = @CurrentId
		SET @CurrentId = @CurrentId+1

		IF OBJECT_ID('tempdb..#FKRelationships') IS NOT NULL DROP TABLE #FKRelationships
	END
END

IF EXISTS (SELECT 1 FROM #SpecialTablesToCheck)
BEGIN
	IF EXISTS (SELECT 1 FROM #SpecialTablesToCheck WHERE [Value] = 'Users')
	BEGIN
		SET @Cmd = N'
		ALTER TABLE [dbo].[Users_NEW] DROP CONSTRAINT [FK_dbo.Users_dbo.Users_ParentId_NEW]
		ALTER TABLE [dbo].[Users_NEW] ALTER COLUMN ParentId VARCHAR(100)'

		EXEC (@Cmd)
		
		SET @Cmd = N'
		INSERT INTO [dbo].[Users_NEW] (Id_OLD, Name,
		LastName, Email, Password, EntryDate, LeavingDate,
		CompanyId, ParentId, Pin)
		SELECT U.Id, U.Name, U.LastName, U.Email,
		U.Password, U.EntryDate, U.LeavingDate,
		CN.Id [CompanyId], U.ParentId, U.Pin
		FROM dbo.Users U
		JOIN dbo.Companies_NEW CN
		ON U.CompanyId = CN.Id_OLD

		UPDATE UN1
		SET ParentId = UN2.Id
		FROM [dbo].[Users_NEW] UN1
		JOIN [dbo].[Users_NEW] UN2
		ON UN1.ParentId = UN2.Id_OLD'
		
		EXEC (@Cmd)

		SET @Cmd = N'
		ALTER TABLE [dbo].[Users_NEW] ALTER COLUMN ParentId UNIQUEIDENTIFIER
		ALTER TABLE [dbo].[Users_NEW] ADD CONSTRAINT [FK_dbo.Users_dbo.Users_ParentId_NEW] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Users_NEW]([Id])'

		EXEC (@Cmd)
	END

	IF EXISTS (SELECT 1 FROM #SpecialTablesToCheck WHERE [Value] = 'Roles')
	BEGIN
		SET @Cmd = N'
		INSERT INTO dbo.Roles_NEW (Id_OLD,
		Name, Description, Activate, CompanyId)
		SELECT R.Id, R.Name, R.Description,
		R.Activate, C.Id
		FROM dbo.Roles R (NOLOCK)
		LEFT JOIN dbo.Companies_NEW C (NOLOCK)
		ON R.CompanyId = C.Id_OLD
		'
		EXEC (@Cmd)
	END
	
	IF EXISTS (SELECT 1 FROM #SpecialTablesToCheck WHERE [Value] = 'Petitions')
	BEGIN
		SET @Cmd = N'
		INSERT INTO dbo.Petitions_NEW(Id_OLD, IdUser, 
		IdCompany, Name, Description, Observation, Date)
		SELECT P.Id, U.Id [IdUser], C.Id [IdCompany],
		P.Name, P.Description, P.Observation, P.Date
		FROM dbo.Petitions P (NOLOCK)
		LEFT JOIN dbo.Companies_NEW C (NOLOCK)
		ON P.IdCompany = C.Id_OLD
		LEFT JOIN dbo.Users_NEW U (NOLOCK)
		ON P.IdUser = U.Id_OLD
		'
		EXEC (@Cmd)
	END
END