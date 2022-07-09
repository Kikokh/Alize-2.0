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

-- Drop temp tables if they exist --

IF OBJECT_ID('tempdb..#TablesToCheck') IS NOT NULL DROP TABLE #TablesToCheck
IF OBJECT_ID('tempdb..#FKRelationships') IS NOT NULL DROP TABLE #FKRelationships

SELECT IDENTITY(INT,1,1) AS Id, [Value]
INTO #TablesToCheck
FROM STRING_SPLIT(@TablesToMigrate, '|')
WHERE RTRIM(LTRIM([Value])) <> ''
ORDER BY 1

-- Main non-relationship tables migration --
IF @IsRelationshipTable = 0
BEGIN

	WHILE EXISTS(SELECT 1 FROM #TablesToCheck)
	BEGIN
		SET @TableNm = (SELECT Value FROM #TablesToCheck WHERE Id = @CurrentId)
		SET @Columns =
			(SELECT STRING_AGG(A.[Column], ', ')
			FROM
				(SELECT CASE WHEN ac.name = 'Id' THEN 'Id_OLD' ELSE ac.name END [Column]
				FROM sys.all_objects ao
				JOIN sys.all_columns ac
				ON ao.object_id = ac.object_id
				WHERE ao.name = @TableNm) A)

		SET @Cmd = (SELECT FORMATMESSAGE('INSERT INTO [%s_NEW](%s) SELECT * FROM %s',@TableNm,@Columns,@TableNm))
		SET @TruncCmd = (SELECT FORMATMESSAGE('TRUNCATE TABLE [%s_NEW]',@TableNm))

		EXEC (@TruncCmd)
		EXEC (@Cmd)

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

	END
END