DROP PROCEDURE IF EXISTS [dbo].[CreateIndexesWithNewSchemaSP]

GO

CREATE PROCEDURE [dbo].[CreateIndexesWithNewSchemaSP]
	@TablesToMigrate VARCHAR(MAX)
AS
/*

@TablesToMigrate: Specify here the table names (without schema) that you want to migrate separated by "|" character.
i.e.: 'Applications|Companies|Users'

*/

DECLARE @SchemaName VARCHAR(100)
DECLARE @TableName VARCHAR(256)
DECLARE @IndexName VARCHAR(256)
DECLARE @ColumnName VARCHAR(100)
DECLARE @is_unique VARCHAR(100)
DECLARE @IndexTypeDesc VARCHAR(100)
DECLARE @FileGroupName VARCHAR(100)
DECLARE @is_disabled VARCHAR(100)
DECLARE @IndexOptions VARCHAR(MAX)
DECLARE @IndexColumnId INT
DECLARE @IsDescendingKey INT
DECLARE @IsIncludedColumn INT
DECLARE @TSQLScripCreationIndex VARCHAR(MAX)
DECLARE @TSQLScripDisableIndex VARCHAR(MAX)

IF OBJECT_ID('tempdb..#TablesToCheck') IS NOT NULL DROP TABLE #TablesToCheck
IF OBJECT_ID('tempdb..#Commands') IS NOT NULL DROP TABLE #Commands

SELECT [Value]
INTO #TablesToCheck
FROM STRING_SPLIT(@TablesToMigrate, '|')
WHERE RTRIM(LTRIM([Value])) <> ''
ORDER BY 1

CREATE TABLE #Commands (Id INT IDENTITY(1,1), Cmd VARCHAR(MAX))

DECLARE CURSORINDEX CURSOR FOR
  SELECT schema_name(T.schema_id)              [schema_name]
         ,T.NAME
         ,IX.NAME
         ,CASE
            WHEN IX.is_unique = 1 THEN 'UNIQUE '
            ELSE ''
          END
         ,IX.type_desc
         ,CASE WHEN IX.is_padded=1 THEN 'PAD_INDEX = ON, ' ELSE
          'PAD_INDEX = OFF, ' END +
          CASE WHEN IX.allow_page_locks=1 THEN 'ALLOW_PAGE_LOCKS = ON, ' ELSE
          'ALLOW_PAGE_LOCKS = OFF, ' END + CASE WHEN IX.allow_row_locks=1 THEN
          'ALLOW_ROW_LOCKS = ON, ' ELSE 'ALLOW_ROW_LOCKS = OFF, ' END + CASE
          WHEN
          Indexproperty(T.object_id, IX.NAME, 'IsStatistics') = 1 THEN
          'STATISTICS_NORECOMPUTE = ON, ' ELSE 'STATISTICS_NORECOMPUTE = OFF, '
          END +
          CASE
          WHEN IX.ignore_dup_key=1 THEN 'IGNORE_DUP_KEY = ON, ' ELSE
          'IGNORE_DUP_KEY = OFF, ' END
          + 'SORT_IN_TEMPDB = OFF, FILLFACTOR ='
          + CASE WHEN IX.fill_factor = 0 THEN '100' ELSE CAST(IX.fill_factor AS VARCHAR(3)) END AS IndexOptions
         ,IX.is_disabled
         ,FILEGROUP_NAME(IX.data_space_id)     FileGroupName
  FROM   SYS.tables T
         INNER JOIN SYS.indexes IX
         ON T.object_id = IX.object_id
  WHERE  IX.type > 0
         AND IX.is_primary_key = 0
         AND IX.is_unique_constraint = 0
         --AND schema_name(t.schema_id)= @SchemaName
		 AND T.name IN (SELECT Value FROM #TablesToCheck)
         AND T.is_ms_shipped = 0
         AND T.NAME <> 'sysdiagrams'
  ORDER  BY schema_name(T.schema_id), T.NAME, IX.NAME

OPEN CURSORINDEX

FETCH NEXT FROM CURSORINDEX INTO @SchemaName, @TableName, @IndexName, @is_unique
, @IndexTypeDesc, @IndexOptions, @is_disabled, @FileGroupName

WHILE ( @@fetch_status = 0 )
  BEGIN
      DECLARE @IndexColumns VARCHAR(MAX)
      DECLARE @IncludedColumns VARCHAR(MAX)

      SET @IndexColumns=''
      SET @IncludedColumns=''

      DECLARE CURSORINDEXCOLUMN CURSOR FOR
        SELECT COL.NAME
               ,IXC.is_descending_key
               ,IXC.is_included_column
        FROM   SYS.tables TB
               INNER JOIN SYS.indexes IX
                       ON TB.object_id = IX.object_id
               INNER JOIN SYS.index_columns IXC
                       ON IX.object_id = IXC.object_id
                          AND IX.index_id = IXC.index_id
               INNER JOIN SYS.columns COL
                       ON IXC.object_id = COL.object_id
                          AND IXC.column_id = COL.column_id
        WHERE  IX.type > 0
               AND ( IX.is_primary_key = 0
                      OR IX.is_unique_constraint = 0 )
               AND schema_name(TB.schema_id) = @SchemaName
               AND TB.NAME = @TableName
               AND IX.NAME = @IndexName
        ORDER  BY IXC.index_column_id

      OPEN CURSORINDEXCOLUMN

      FETCH NEXT FROM CURSORINDEXCOLUMN INTO @ColumnName, @IsDescendingKey,
      @IsIncludedColumn

      WHILE ( @@fetch_status = 0 )
        BEGIN
            IF @IsIncludedColumn = 0
              SET @IndexColumns=@IndexColumns + @ColumnName + CASE WHEN
                                @IsDescendingKey
                                =1
                                                         THEN ' DESC, ' ELSE
                                                         ' ASC, ' END
            ELSE
              SET @IncludedColumns=@IncludedColumns + @ColumnName + ', '

            FETCH NEXT FROM CURSORINDEXCOLUMN INTO @ColumnName, @IsDescendingKey
            ,
            @IsIncludedColumn
        END

      CLOSE CURSORINDEXCOLUMN

      DEALLOCATE CURSORINDEXCOLUMN

      SET @IndexColumns = Substring(@IndexColumns, 1, Len(@IndexColumns) - 1)
      SET @IncludedColumns = CASE
                               WHEN Len(@IncludedColumns) > 0 THEN
                               Substring(@IncludedColumns, 1,
                               Len(@IncludedColumns) - 1)
                               ELSE ''
                             END
      --  print @IndexColumns
      --  print @IncludedColumns
      SET @TSQLScripCreationIndex =''
      SET @TSQLScripDisableIndex =''
      SET @TSQLScripCreationIndex='CREATE ' + @is_unique + @IndexTypeDesc
                                  + ' INDEX ' + Quotename(@IndexName) + ' ON '
                                  + Quotename(@SchemaName) + '.'
                                  + Quotename(@TableName+'_NEW')+ '(' + @IndexColumns
                                  + ') ' + CASE WHEN Len(@IncludedColumns)>0
                                  THEN
                                  Char
                                  (13) +'INCLUDE (' + @IncludedColumns+ ')' ELSE
                                  ''
                                  END + Char(13) + 'WITH (' + @IndexOptions
                                  + ') ON ' + Quotename(@FileGroupName) + ';'

      IF @is_disabled = 1
        SET @TSQLScripDisableIndex= Char(13) + 'ALTER INDEX '
                                    + Quotename(@IndexName) + ' ON '
                                    + Quotename(@SchemaName) + '.'
                                    + Quotename(@TableName) + ' DISABLE;' + Char
                                    (
                                    13)
	  
	  IF LTRIM(RTRIM(@TSQLScripCreationIndex)) <> ''
		INSERT INTO #Commands SELECT FORMATMESSAGE('DROP INDEX IF EXISTS %s ON %s.%s_NEW',@IndexName,@SchemaName,@TableName) UNION ALL SELECT @TSQLScripCreationIndex

	  IF LTRIM(RTRIM(@TSQLScripDisableIndex)) <> ''
		INSERT INTO #Commands SELECT @TSQLScripDisableIndex

      FETCH NEXT FROM CURSORINDEX INTO @SchemaName, @TableName, @IndexName,
      @is_unique, @IndexTypeDesc, @IndexOptions, @is_disabled, @FileGroupName
  END

CLOSE CURSORINDEX

DEALLOCATE CURSORINDEX

DECLARE @CurrentId INT = 1
DECLARE @CurrentCmd VARCHAR(MAX)

WHILE EXISTS(SELECT 1 FROM #Commands)
BEGIN
	SET @CurrentCmd = (SELECT Cmd FROM #Commands WHERE Id = @CurrentId)
	EXEC (@CurrentCmd)

	DELETE FROM #Commands WHERE Id = @CurrentId
	SET @CurrentId = @CurrentId+1
END