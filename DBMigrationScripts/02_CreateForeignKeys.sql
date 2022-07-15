DROP PROCEDURE IF EXISTS [dbo].[CreateForeignKeys]

GO

CREATE PROCEDURE [dbo].[CreateForeignKeys]
AS
DECLARE @CurrentId SMALLINT = 1
DECLARE @Cmd VARCHAR(MAX)

-- Drop temp tables if they exist --

IF OBJECT_ID('tempdb..#FKRelationships') IS NOT NULL DROP TABLE #FKRelationships

SELECT IDENTITY(INT,1,1) AS Id, N'
ALTER TABLE ' 
   + QUOTENAME(cs.name) + '.' + QUOTENAME(ct.name+'_NEW') 
   + ' ADD CONSTRAINT ' + QUOTENAME(fk.name+'_NEW') 
   + ' FOREIGN KEY (' + STUFF((SELECT ',' + QUOTENAME(c.name)
    FROM sys.columns AS c 
    INNER JOIN sys.foreign_key_columns AS fkc 
    ON fkc.parent_column_id = c.column_id
    AND fkc.parent_object_id = c.[object_id]
    WHERE fkc.constraint_object_id = fk.[object_id]
    ORDER BY fkc.constraint_column_id 
    FOR XML PATH(N''), TYPE).value(N'.[1]', N'nvarchar(max)'), 1, 1, N'')
  + ') REFERENCES ' + QUOTENAME(rs.name) + '.' + QUOTENAME(rt.name+'_NEW')
  + '(' + STUFF((SELECT ',' + QUOTENAME(c.name)
    FROM sys.columns AS c 
    INNER JOIN sys.foreign_key_columns AS fkc 
    ON fkc.referenced_column_id = c.column_id
    AND fkc.referenced_object_id = c.[object_id]
    WHERE fkc.constraint_object_id = fk.[object_id]
    ORDER BY fkc.constraint_column_id 
    FOR XML PATH(N''), TYPE).value(N'.[1]', N'nvarchar(max)'), 1, 1, N'') + ');' [Cmd]
INTO #FKRelationships
FROM sys.foreign_keys AS fk
INNER JOIN sys.tables AS rt -- referenced table
  ON fk.referenced_object_id = rt.[object_id]
INNER JOIN sys.schemas AS rs 
  ON rt.[schema_id] = rs.[schema_id]
INNER JOIN sys.tables AS ct -- constraint table
  ON fk.parent_object_id = ct.[object_id]
INNER JOIN sys.schemas AS cs 
  ON ct.[schema_id] = cs.[schema_id]
WHERE rt.is_ms_shipped = 0 AND ct.is_ms_shipped = 0

WHILE EXISTS(SELECT 1 FROM #FKRelationships)
BEGIN

	SET @Cmd = (SELECT Cmd FROM #FKRelationships WHERE Id = @CurrentId)

	EXEC (@Cmd)

	DELETE FROM #FKRelationships WHERE Id = @CurrentId
	SET @CurrentId = @CurrentId+1

END