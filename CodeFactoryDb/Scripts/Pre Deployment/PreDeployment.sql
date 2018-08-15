--/*
-- Pre-Deployment Script Template							
----------------------------------------------------------------------------------------
-- This file contains SQL statements that will be executed before the build script.	
-- Use SQLCMD syntax to include a file in the pre-deployment script.			
-- Example:      :r .\myfile.sql								
-- Use SQLCMD syntax to reference a variable in the pre-deployment script.		
-- Example:      :setvar TableName MyTable							
--               SELECT * FROM [$(TableName)]					
----------------------------------------------------------------------------------------
--*/

--DECLARE @ReturnClr TABLE(name nvarchar(128),minimum nvarchar(128),maximum nvarchar(128),config_value nvarchar(128),run_value nvarchar(128))
--INSERT INTO @ReturnClr
--EXEC sp_configure 'clr enabled'

--IF NOT EXISTS(SELECT 1 FROM @ReturnClr WHERE config_value = '1')
--BEGIN
--    EXEC sp_configure 'show advanced options', 1;
--    RECONFIGURE;
--    EXEC sp_configure 'clr enabled', 1;
--    RECONFIGURE;
--    EXEC sp_configure 'show advanced options', 0;
--END

--:r .\CreateLinkServer.sql