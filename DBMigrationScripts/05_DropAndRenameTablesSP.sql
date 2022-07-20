DROP PROCEDURE IF EXISTS [dbo].[DropAndRenameTablesSP]

GO

CREATE PROCEDURE [dbo].[DropAndRenameTablesSP]
AS

DECLARE @CurrentId SMALLINT = 1
DECLARE @Columns VARCHAR(MAX)
DECLARE @TableNm_New VARCHAR(100)
DECLARE @TableNm_Old VARCHAR(100)
DECLARE @Cmd_Columns VARCHAR(MAX)
DECLARE @Cmd_Tables VARCHAR(MAX)
DECLARE @Cmd_DropOldFKs VARCHAR(MAX)
DECLARE @Cmd_DropOldTables VARCHAR(MAX)

-- Drop temp tables if they exist --

IF OBJECT_ID('tempdb..#TablesToCheck') IS NOT NULL DROP TABLE #TablesToCheck

SELECT IDENTITY(INT,1,1) AS Id, t.name
INTO #TablesToCheck
FROM sys.tables t
WHERE t.name LIKE '%_NEW'
ORDER BY 1

WHILE EXISTS(SELECT 1 FROM #TablesToCheck)
BEGIN

	SET @TableNm_New = (SELECT tc.name FROM #TablesToCheck tc WHERE Id = @CurrentId)
	SET @TableNm_Old = (SELECT REPLACE(tc.name, '_NEW','') FROM #TablesToCheck tc WHERE Id = @CurrentId)

	
	SET @Columns = (SELECT ac.name
				FROM sys.all_objects ao
				JOIN sys.all_columns ac
				ON ao.object_id = ac.object_id
				WHERE ao.name = @TableNm_New AND ac.name = 'Id_OLD')

	IF @Columns IS NOT NULL
	BEGIN
		SET @Cmd_Columns = (SELECT FORMATMESSAGE('ALTER TABLE %s DROP COLUMN %s',@TableNm_New, @Columns))
		EXEC (@Cmd_Columns)
	END

	SET @Cmd_DropOldFKs =
	(SELECT 'ALTER TABLE [' + OBJECT_SCHEMA_NAME(parent_object_id) + '].[' + OBJECT_NAME(parent_object_id) +
				'] DROP CONSTRAINT [' + name + ']'
	FROM sys.foreign_keys 
	WHERE OBJECT_SCHEMA_NAME(referenced_object_id) = 'dbo'
	AND OBJECT_NAME(referenced_object_id) = @TableNm_Old)
	
	EXEC (@Cmd_DropOldFKs)

	SET @Cmd_DropOldTables = (SELECT FORMATMESSAGE('DROP TABLE %s', @TableNm_Old))

	EXEC (@Cmd_DropOldTables)

	SET @Cmd_Tables = (SELECT FORMATMESSAGE('sp_RENAME ''%s'' , ''%s''',@TableNm_New, @TableNm_Old))
		
	EXEC (@Cmd_Tables)

	DELETE FROM #TablesToCheck WHERE Id = @CurrentId
	SET @CurrentId = @CurrentId+1

END
