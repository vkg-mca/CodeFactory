--sp_configure 'clr enable', 1
--GO

--RECONFIGURE
--GO

--ALTER DATABASE CodeFactoryDb SET TRUSTWORTHY ON
--GO


--IF EXISTS(select 'X' FROM sys.assemblies WHERE name = 'CodeFactoryDb')
--DROP ASSEMBLY [CodeFactoryDb]
--GO

--CREATE ASSEMBLY [CodeFactoryDb]
--AUTHORIZATION dbo
--FROM 'D:\Development\CodeFactory\CodeFactoryDb\CodeFactoryDb\bin\Debug\CodeFactoryDb.dll'
--WITH PERMISSION_SET = UNSAFE
--GO


