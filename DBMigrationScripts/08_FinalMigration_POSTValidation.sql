-- 01 - Validate migrated data
EXEC [dbo].[ValidationDataSP]

-- 02 - Drop old tables and rename new ones
EXEC [dbo].[DropAndRenameTablesSP]