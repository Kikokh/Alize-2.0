DROP PROCEDURE IF EXISTS [dbo].[CreateForeignKeys]

GO

CREATE PROCEDURE [dbo].[CreateForeignKeys]
AS

DECLARE @SpecialTables TABLE (TableNm VARCHAR(100), NewTableNm VARCHAR(100))
INSERT INTO @SpecialTables VALUES ('Users', 'AspNetUsers'), ('Roles', 'AspNetRoles')

DECLARE @CurrentId SMALLINT = 1
DECLARE @Cmd VARCHAR(MAX)

-- Drop temp tables if they exist --

IF OBJECT_ID('tempdb..#FKRelationships') IS NOT NULL DROP TABLE #FKRelationships

SELECT IDENTITY(INT,1,1) AS Id, Cmd
INTO #FKRelationships
FROM
(SELECT N'
ALTER TABLE ' 
   + QUOTENAME(cs.name) + '.' + 
   CASE WHEN ST.TableNm IS NOT NULL
   THEN QUOTENAME(ST.NewTableNm+'_NEW') 
   ELSE QUOTENAME(ct.name+'_NEW') 
   END
   + 
   CASE WHEN ST.TableNm IS NULL AND ST2.TableNm IS NULL
   THEN
		' ADD CONSTRAINT ' + QUOTENAME(REPLACE(fk.name, rs.name+'.','')+'_NEW') 
   WHEN ST.TableNm IS NOT NULL
   THEN
		' ADD CONSTRAINT ' + QUOTENAME(REPLACE(REPLACE(fk.name, rs.name+'.',''), ST.TableNm, ST.NewTableNm)+'_NEW')
   WHEN ST2.TableNm IS NOT NULL
   THEN
		' ADD CONSTRAINT ' + QUOTENAME(REPLACE(REPLACE(fk.name, rs.name+'.',''), ST2.TableNm, ST2.NewTableNm)+'_NEW')
   END
   + ' FOREIGN KEY (' + STUFF((SELECT ',' + QUOTENAME(c.name)
    FROM sys.columns AS c 
    INNER JOIN sys.foreign_key_columns AS fkc 
    ON fkc.parent_column_id = c.column_id
    AND fkc.parent_object_id = c.[object_id]
    WHERE fkc.constraint_object_id = fk.[object_id]
    ORDER BY fkc.constraint_column_id 
    FOR XML PATH(N''), TYPE).value(N'.[1]', N'nvarchar(max)'), 1, 1, N'')
  + ') REFERENCES ' + QUOTENAME(rs.name) + '.' + 
   CASE WHEN ST2.TableNm IS NOT NULL
   THEN QUOTENAME(ST2.NewTableNm+'_NEW') 
   ELSE QUOTENAME(rt.name+'_NEW') 
   END
  + '(' + STUFF((SELECT ',' + QUOTENAME(c.name)
    FROM sys.columns AS c 
    INNER JOIN sys.foreign_key_columns AS fkc 
    ON fkc.referenced_column_id = c.column_id
    AND fkc.referenced_object_id = c.[object_id]
    WHERE fkc.constraint_object_id = fk.[object_id]
    ORDER BY fkc.constraint_column_id 
    FOR XML PATH(N''), TYPE).value(N'.[1]', N'nvarchar(max)'), 1, 1, N'') + ');' [Cmd]
FROM sys.foreign_keys AS fk
INNER JOIN sys.tables AS rt -- referenced table
  ON fk.referenced_object_id = rt.[object_id]
INNER JOIN sys.schemas AS rs 
  ON rt.[schema_id] = rs.[schema_id]
INNER JOIN sys.tables AS ct -- constraint table
  ON fk.parent_object_id = ct.[object_id]
INNER JOIN sys.schemas AS cs 
  ON ct.[schema_id] = cs.[schema_id]
LEFT JOIN @SpecialTables ST
ON ct.name = ST.TableNm
LEFT JOIN @SpecialTables ST2
ON rt.name = ST2.TableNm
WHERE rt.is_ms_shipped = 0 AND ct.is_ms_shipped = 0
AND ct.name NOT LIKE '%[_]NEW'
  UNION ALL
SELECT N'  ALTER TABLE [dbo].[Petitions_NEW] ADD CONSTRAINT [FK_Petitions_AspNetUsers_UserId_NEW] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[AspNetUsers_NEW]([Id]);' UNION ALL
SELECT N'  ALTER TABLE [dbo].[Petitions_NEW] ADD CONSTRAINT [FK_Petitions_Companies_CompanyId_NEW] FOREIGN KEY ([IdCompany]) REFERENCES [dbo].[Companies_NEW]([Id]);') A

WHILE EXISTS(SELECT 1 FROM #FKRelationships)
BEGIN

	SET @Cmd = (SELECT Cmd FROM #FKRelationships WHERE Id = @CurrentId)

	EXEC (@Cmd)

	DELETE FROM #FKRelationships WHERE Id = @CurrentId
	SET @CurrentId = @CurrentId+1

END