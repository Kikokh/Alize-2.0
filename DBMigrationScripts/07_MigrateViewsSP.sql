DROP PROCEDURE IF EXISTS [dbo].[MigrateViewsSP]

GO

CREATE PROCEDURE [dbo].[MigrateViewsSP]
AS

DECLARE @CurrentId SMALLINT = 1
DECLARE @ViewNm VARCHAR(100)
DECLARE @AlterViewCmd TABLE (Cmd VARCHAR(MAX))
DECLARE @NewCmd VARCHAR(MAX)

IF OBJECT_ID('tempdb..#ViewsToCheck') IS NOT NULL DROP TABLE #ViewsToCheck

SELECT IDENTITY(INT,1,1) AS Id,
S.name+'.'+V.name [ViewNm]
INTO #ViewsToCheck
FROM sys.views V
JOIN sys.schemas S
ON V.schema_id = S.schema_id

WHILE EXISTS(SELECT 1 FROM #ViewsToCheck)
BEGIN
	SET @ViewNm = (SELECT [ViewNm] FROM #ViewsToCheck WHERE Id = @CurrentId)
	SET @NewCmd = ''

	INSERT INTO @AlterViewCmd EXEC sp_helptext @ViewNm	

	SELECT @NewCmd = COALESCE(@NewCmd + ' ' + Cmd, Cmd)
	FROM @AlterViewCmd

	SET @NewCmd = REPLACE(@NewCmd, 'CREATE VIEW',		'ALTER VIEW')
	SET @NewCmd = REPLACE(@NewCmd, 'dbo.Users',			'dbo.AspNetUsers')
	SET @NewCmd = REPLACE(@NewCmd, 'dbo.Roles',			'dbo.AspNetRoles')
	SET @NewCmd = REPLACE(@NewCmd, 'AspNetUsers.Name',		'AspNetUsers.FirstName')
	SET @NewCmd = REPLACE(@NewCmd, 'AspNetUsers.Password',	'AspNetUsers.PasswordHash')

	--SELECT @NewCmd
	EXEC (@NewCmd)

	DELETE FROM #ViewsToCheck WHERE Id = @CurrentId
	SET @CurrentId = @CurrentId+1
END