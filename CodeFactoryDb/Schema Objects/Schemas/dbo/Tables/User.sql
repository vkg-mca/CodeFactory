CREATE TABLE [dbo].[User]
(
	[OID] OIDType NOT NULL PRIMARY KEY DEFAULT NEWID ( ), 
	[UserName] VARCHAR(25) NOT NULL, 
	[Title] VARCHAR(5) NOT NULL, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [MiddleName] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [GenderOID] UNIQUEIDENTIFIER NOT NULL, 
    [DateOfBirth] DATETIME2 NOT NULL, 
    [StatusOID] UNIQUEIDENTIFIER NOT NULL , 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT GetDate(), 
    [CreatedBy] VARCHAR(50) NOT NULL DEFAULT SYSTEM_USER, 
	[RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [GenderFK] FOREIGN KEY ([GenderOID]) REFERENCES [CodeSet]([OID]), 
    CONSTRAINT [StatusFK] FOREIGN KEY ([StatusOID])  REFERENCES [CodeSet]([OID])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Primary Key',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = N'OID'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Mr./Dr./Miss/Mrs./Jr./Sr.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = N'Title'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'First name',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = N'FirstName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Middle name',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = N'MiddleName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Last Name',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = N'LastName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Gender code from codeset',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = N'GenderOID'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Date of birth',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = N'DateOfBirth'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Record status from codeset',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = N'StatusOID'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Date when this record created',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'who cerated this record',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'