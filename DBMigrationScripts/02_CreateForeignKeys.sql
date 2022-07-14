DROP PROCEDURE IF EXISTS [dbo].[CreateForeignKeys]

GO

CREATE PROCEDURE [dbo].[MigrateDataToNewTablesSP]
	@TablesToMigrate VARCHAR(MAX)
AS
DECLARE @CurrentId SMALLINT = 1
DECLARE @TableNm VARCHAR(100)
DECLARE @Cmd VARCHAR(MAX)
DECLARE @fk_name VARCHAR(MAX)
DECLARE @schema_name VARCHAR(MAX)
DECLARE @table VARCHAR(MAX)
DECLARE @column VARCHAR(MAX)
DECLARE @referenced_table VARCHAR(MAX)
DECLARE @referenced_column VARCHAR(MAX)

-- Drop temp tables if they exist --

IF OBJECT_ID('tempdb..#TablesToCheck') IS NOT NULL DROP TABLE #TablesToCheck
IF OBJECT_ID('tempdb..#FKRelationships') IS NOT NULL DROP TABLE #FKRelationships

SELECT IDENTITY(INT,1,1) AS Id, [Value]
INTO #TablesToCheck
FROM STRING_SPLIT(@TablesToMigrate, '|')
WHERE RTRIM(LTRIM([Value])) <> ''
ORDER BY 1

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

		SET @fk_name = (SELECT TOP 1 FK_NAME FROM #FKRelationships WHERE [table] = @TableNm)
		SET @schema_name = (SELECT TOP 1 [schema_name] FROM #FKRelationships WHERE [table] = @TableNm)
		SET @table = (SELECT TOP 1 [table] FROM #FKRelationships WHERE [table] = @TableNm)
		SET @column = (SELECT TOP 1 [column] FROM #FKRelationships WHERE [table] = @TableNm)
		SET @referenced_table = (SELECT TOP 1 [referenced_table] FROM #FKRelationships WHERE [table] = @TableNm)
		SET @referenced_column = (SELECT TOP 1 [referenced_column] FROM #FKRelationships WHERE [table] = @TableNm)

SET @Cmd = (SELECT FORMATMESSAGE('ALTER TABLE %s.%s_NEW ADD CONSTRAINT [FK_%s.%s] FOREIGN KEY (%s) REFERENCES %s.%s_NEW(%s)',
		@schema_name, @table, @table, @referenced_table, @column, @schema_name, @referenced_table, @referenced_column))

EXEC (@Cmd)

DELETE FROM #TablesToCheck WHERE Id = @CurrentId
		SET @CurrentId = @CurrentId+1
END