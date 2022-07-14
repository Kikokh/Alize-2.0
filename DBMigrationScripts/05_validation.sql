DROP PROCEDURE IF EXISTS [dbo].[ValidationDataSP]

GO

CREATE PROCEDURE [dbo].[ValidationDataSP]
AS

DECLARE @CurrentId SMALLINT = 1
DECLARE @TableNm_New VARCHAR(100)
DECLARE @TableNm_Old VARCHAR(100)
DECLARE @Error_Validation VARCHAR(100)
DECLARE @Cmd VARCHAR(MAX)


-- Drop temp tables if they exist --

IF OBJECT_ID('tempdb..#Tables_Old') IS NOT NULL DROP TABLE #Tables;



SELECT 
	IDENTITY(INT,1,1) AS Id, 
	tab.name AS [name]
INTO #Tables_Old
FROM sys.objects obj
JOIN sys.tables tab ON tab.object_id = obj.object_id
WHERE tab.name NOT LIKE '%_NEW';

WHILE EXISTS(SELECT 1 FROM #Tables_Old)
BEGIN

	SET @TableNm_New = (SELECT tc.name + '_NEW' FROM #Tables_Old tc WHERE Id = @CurrentId)
	SET @TableNm_Old = (SELECT tc.name FROM #Tables_Old tc WHERE Id = @CurrentId)
	
	SET @Cmd = (SELECT FORMATMESSAGE('@Error_Validation = (
		SELECT * FROM %s
		EXCEPT
		SELECT * FROM %s)',@TableNm_Old, @TableNm_New))
		EXEC (@Cmd)

	IF @Error_Validation IS NULL RAISERROR(N' Validation Failed', 16, 1);
	
	DELETE FROM #Tables_Old WHERE Id = @CurrentId
	SET @CurrentId = @CurrentId+1

END
