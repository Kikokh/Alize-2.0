DECLARE @INCLUSIONLIST VARCHAR(MAX) = '|Applications|Users|'

-- Drop temp tables if they exist --

IF OBJECT_ID('tempdb..#TablesToCheck') IS NOT NULL DROP TABLE #TablesToCheck
IF OBJECT_ID('tempdb..#GetCurrentTablesInfo') IS NOT NULL DROP TABLE #GetCurrentTablesInfo
IF OBJECT_ID('tempdb..#TablesWithIdentity') IS NOT NULL DROP TABLE #TablesWithIdentity

-- Convert INCLUSIONLIST values into a table --

SELECT [Value]
INTO #TablesToCheck
FROM STRING_SPLIT(@INCLUSIONLIST, '|')
WHERE RTRIM(LTRIM([Value])) <> ''
ORDER BY 1

-- Get current tables schema info --

SELECT A.t_name, A.rownum, A.max_column_id, C.column_id, C.c_name, C.datatype, C.systemtype,
C.length, C.precision, C.scale, C.is_nullable, C.default_definition, C.identity_seed,
C.identity_increment, PK.pk_name, PK.pk_columns
INTO #GetCurrentTablesInfo
FROM
	  (SELECT t.t_name, rownum, max_column_id
       FROM
			(SELECT t.name as t_name, MAX(c.column_id) as max_column_id
             FROM sys.columns c
			 JOIN
                (SELECT * FROM sys.tables WHERE CHARINDEX('|'+name+'|', @INCLUSIONLIST) > 0 ) t
             ON c.object_id = t.object_id
             GROUP BY t.name) t
	   JOIN
		(SELECT ROW_NUMBER() OVER (ORDER BY object_id) as rownum FROM sys.columns c) ctr
       ON ctr.rownum <= t.max_column_id + 5) A
LEFT JOIN
      (SELECT t.name as t_name, c.column_id, c.name AS c_name, u.name as datatype,
              ISNULL(baset.name, N'') AS systemtype,
              CAST(CASE WHEN baset.name IN (N'nchar', N'nvarchar') AND c.max_length <> -1
                        THEN c.max_length/2 ELSE c.max_length END AS INT) AS length,
              c.precision AS precision,
              c.scale as scale,
              c.is_nullable,
              dc.definition as default_definition,
              idc.seed_value as identity_seed, idc.increment_value as identity_increment
       FROM sys.tables t
	   JOIN sys.all_columns AS c
       ON c.object_id = t.object_id
	   LEFT JOIN sys.types u
	   ON u.user_type_id = c.user_type_id
	   LEFT JOIN sys.types baset
	   ON baset.user_type_id = c.system_type_id
	   AND baset.user_type_id = baset.system_type_id
	   LEFT JOIN sys.default_constraints dc
	   ON c.object_id = dc.parent_object_id
	   AND c.column_id = dc.parent_column_id
	   LEFT JOIN sys.identity_columns idc
	   ON c.object_id = idc.object_id
	   AND c.column_id = idc.column_id) C
ON A.t_name = C.t_name
AND C.column_id + 1 = A.rownum
LEFT JOIN
    (SELECT t.name as t_name, kc.name as pk_name, 
       (MAX(CASE WHEN index_column_id = 1 THEN '['+c.name+']' ELSE '' END) +
        MAX(CASE WHEN index_column_id = 2 THEN ','+'['+c.name+']' ELSE '' END) +
        MAX(CASE WHEN index_column_id = 3 THEN ','+'['+c.name+']' ELSE '' END) +
        MAX(CASE WHEN index_column_id = 4 THEN ','+'['+c.name+']' ELSE '' END) +
        MAX(CASE WHEN index_column_id = 5 THEN ','+'['+c.name+']' ELSE '' END) +
        MAX(CASE WHEN index_column_id = 6 THEN ','+'['+c.name+']' ELSE '' END) +
        MAX(CASE WHEN index_column_id = 7 THEN ','+'['+c.name+']' ELSE '' END) +
        MAX(CASE WHEN index_column_id = 8 THEN ','+'['+c.name+']' ELSE '' END) +
        MAX(CASE WHEN index_column_id = 9 THEN ','+'['+c.name+']' ELSE '' END) +
        MAX(CASE WHEN index_column_id = 10 THEN ','+'['+c.name+']' ELSE '' END)) as pk_columns
    FROM sys.indexes i
	JOIN sys.key_constraints kc
    ON i.name = kc.name
    AND kc.type = 'PK'
	JOIN sys.tables t
    ON i.object_id = t.object_id
	JOIN sys.index_columns ic
    ON i.object_id = ic.object_id
	AND i.index_id = ic.index_id
	JOIN sys.columns c
    ON ic.index_column_id = c.column_id
	AND ic.object_id = c.object_id
    GROUP BY t.name, kc.name) PK
ON PK.t_name = A.t_name 

-- Get tables with existing identity column and add new GUID column --

SELECT G.t_name, G.c_name
INTO #TablesWithIdentity
FROM #GetCurrentTablesInfo G
JOIN #TablesToCheck T
ON G.t_name = T.[Value]
WHERE G.identity_seed = 1

UPDATE G
SET rownum = (CASE WHEN G.rownum > 1 THEN G.rownum+1 ELSE G.rownum END),
c_name = CASE WHEN G.identity_seed = 1 THEN 'Id_OLD' ELSE G.c_name END,
max_column_id = G.max_column_id+1,
identity_seed = NULL,
identity_increment = NULL
FROM #GetCurrentTablesInfo G
JOIN #TablesWithIdentity T
ON G.t_name = T.t_name

INSERT INTO #GetCurrentTablesInfo
SELECT DISTINCT T.t_name, 2 [rownum], G.max_column_id, 1 [column_id], 'GUID' [c_name],
'uniqueidentifier' [datatype], 'uniqueidentifier' [systemtype], 16 [length], 0 [precision], 
0 [scale], 0 [is_nullable], 'NEWID()' [default_definition], NULL [identity_seed],
NULL [identity_increment], G.pk_name+'_NEW' [pk_name], '[GUID]' [pk_columns]
FROM #GetCurrentTablesInfo G
JOIN #TablesWithIdentity T
ON G.t_name = T.t_name

-- Print CREATE TABLE queries --

SELECT (CASE WHEN rownum = 1 THEN 'CREATE TABLE ['+t_name+'_NEW] ('
             WHEN column_id IS NOT NULL
             THEN '    ['+c_name+'] ' +
                  (CASE WHEN CHARINDEX('CHAR', datatype) > 0 THEN UPPER(datatype+'('+(case when length < 0 then 'MAX' else cast(length as varchar) end)+')')
                        WHEN CHARINDEX('BINARY', datatype) > 0 THEN UPPER(datatype+'('+cast(length as varchar)+')')
                        WHEN datatype = 'FLOAT' AND precision <> 24 THEN UPPER(datatype+'('+cast(precision as varchar)+')')
                        WHEN datatype IN ('NUMERIC', 'DECIMAL') AND scale = 0 THEN UPPER(datatype+'('+cast(precision as varchar)+')')
                        WHEN datatype IN ('NUMERIC', 'DECIMAL') AND scale > 0 THEN UPPER(datatype+'('+cast(precision as varchar)+','+cast(scale as varchar)+')')
                        ELSE UPPER(datatype) END)+' '+
                  --(CASE WHEN c.identity_seed IS NOT NULL
                  --      THEN 'IDENTITY(' + CAST(identity_seed AS VARCHAR) + ',' + CAST(identity_increment AS VARCHAR) + ') '
                  --      ELSE '' END) +
                  (CASE WHEN is_nullable = 0 THEN 'NOT NULL' ELSE '' END) +
                  (CASE WHEN default_definition IS NOT NULL
                        THEN ' DEFAULT '+default_definition ELSE '' END) +
                  (CASE WHEN max_column_id = column_id AND pk_name IS NULL THEN '' ELSE ',' END)
            WHEN rownum = max_column_id + 2 and pk_name IS NOT NULL
            THEN '    PRIMARY KEY ([GUID])'
            WHEN rownum = max_column_id + 3 THEN ')'
            WHEN rownum = max_column_id + 4 THEN 'GO'
            WHEN rownum = max_column_id + 5 THEN ''
        END)
 FROM #GetCurrentTablesInfo G
ORDER BY t_name, rownum