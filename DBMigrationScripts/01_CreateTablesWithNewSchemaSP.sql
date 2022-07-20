DROP PROCEDURE IF EXISTS [dbo].[usp_GetErrorInfo]

GO

CREATE PROCEDURE [dbo].[usp_GetErrorInfo] 
AS  
SELECT  
    ERROR_NUMBER() AS ErrorNumber  
    ,ERROR_SEVERITY() AS ErrorSeverity  
    ,ERROR_STATE() AS ErrorState  
    ,ERROR_PROCEDURE() AS ErrorProcedure  
    ,ERROR_LINE() AS ErrorLine  
    ,ERROR_MESSAGE() AS ErrorMessage;  
GO 

DROP PROCEDURE IF EXISTS [dbo].[ValidationDataSP]

GO

CREATE PROCEDURE [dbo].[ValidationDataSP]
AS

DECLARE @CurrentId SMALLINT = 1
DECLARE @CurrentId2 SMALLINT = 1
DECLARE @TableNm_New VARCHAR(100)
DECLARE @TableNm_Old VARCHAR(100)
DECLARE @Column_Name VARCHAR(MAX)
DECLARE @RefColumn VARCHAR(100)
DECLARE @Cmd VARCHAR(MAX)


-- Drop temp tables if they exist --

IF OBJECT_ID('tempdb..#Tables_Old') IS NOT NULL DROP TABLE #Tables_Old;
IF OBJECT_ID('tempdb..#Columns_Old') IS NOT NULL DROP TABLE #Columns_Old;



SELECT 
	IDENTITY(INT,1,1) AS Id, 
	tab.name AS [name],
	c.name [columnId]
INTO #Tables_Old
FROM sys.objects obj
JOIN sys.tables tab ON tab.object_id = obj.object_id
JOIN sys.columns c ON c.object_id = tab.object_id
WHERE c.name = 'Id' AND tab.name NOT LIKE '%_NEW';

WHILE EXISTS(SELECT 1 FROM #Tables_Old)
BEGIN

	SET @TableNm_New = (SELECT tc.name + '_NEW' FROM #Tables_Old tc WHERE Id = @CurrentId)
	SET @TableNm_Old = (SELECT tc.name FROM #Tables_Old tc WHERE Id = @CurrentId)
	
	
	SET @Cmd = (SELECT FORMATMESSAGE(
		'SELECT %s.*
		FROM %s 
		LEFT JOIN %s tn ON %s.Id_Old = %s.Id'
		, @TableNm_Old
		, @TableNm_Old
		, @TableNm_New, @TableNm_New, @TableNm_Old));
	
	EXEC (@Cmd);

	            
	DELETE FROM #Tables_Old WHERE Id = @CurrentId;
	SET @CurrentId = @CurrentId+1;
	
END
SELECT  IDENTITY(INT,1,1) AS Id, 
	obj.name AS FK_NAME,
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



WHILE EXISTS(SELECT 1 FROM #FKRelationships)
BEGIN
	SET @TableNm_Old = (SELECT [table] FROM #FKRelationships WHERE Id = @CurrentId2)
	SET @TableNm_New = (SELECT [table] + '_NEW' FROM #FKRelationships WHERE Id = @CurrentId2)
	SET @Column_Name = (SELECT [column] FROM #FKRelationships WHERE Id = @CurrentId2)
	SET @RefColumn = (SELECT referenced_column FROM #FKRelationships WHERE Id = @CurrentId2)

	SET @Cmd = (SELECT FORMATMESSAGE('SELECT CASE WHEN %s.%s IS NULL THEN "Missing data" ELSE %s.%s::VARCHAR(100)
	FROM %s
	LEFT JOIN %s ON %s.Id = %s.%s'
	, @TableNm_New, @Column_Name, @TableNm_New, @Column_Name
	, @TableNm_Old
	, @TableNm_New
	, @TableNm_New
	, @TableNm_Old
	, @Column_Name));

	EXEC (@Cmd);

	DELETE FROM #FKRelationships WHERE Id = @CurrentId2;
	SET @CurrentId2 = @CurrentId2+1;
END

exec [dbo].[ValidationDataSP]



		