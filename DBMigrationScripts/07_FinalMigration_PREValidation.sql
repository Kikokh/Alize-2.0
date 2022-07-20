-- 01 - New tables creation --	OK
EXEC dbo.CreateTablesWithNewSchemaSP @TablesToMigrate='|Applications|Companies|ExecutionLogs|Logins|ModuleRol|Modules|Petitions|Roles|RolUser|UserApplication|Users|'

-- 02 - Foreign Keys creation --	OK
EXEC [dbo].[CreateForeignKeys]

-- 03 - Indexes creation --	OK
EXEC [dbo].[CreateIndexesWithNewSchemaSP] @TablesToMigrate='|Applications|Companies|ExecutionLogs|Logins|ModuleRol|Modules|Petitions|Roles|RolUser|UserApplication|Users|'

-- 04 - Data migration -- OK
  -- First migrate tables with no Foreign Keys --
	 EXEC [dbo].[MigrateDataToNewTablesSP] @TablesToMigrate='|Companies|ExecutionLogs|Modules|', @IsRelationshipTable=0
  -- Migrate tables that depend upon the previous ones --
	 EXEC [dbo].[MigrateDataToNewTablesSP] @TablesToMigrate='|Applications|Logins|Users|Roles|', @IsRelationshipTable=0
	 EXEC [dbo].[MigrateDataToNewTablesSP] @TablesToMigrate='|Petitions|', @IsRelationshipTable=0
  -- Migrate relationship tables --
	 EXEC [dbo].[MigrateDataToNewTablesSP] @TablesToMigrate='|ModuleRol|RolUser|UserApplication|', @IsRelationshipTable=1