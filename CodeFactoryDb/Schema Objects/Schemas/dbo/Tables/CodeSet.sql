CREATE TABLE [dbo].[CodeSet]
(
	[OID] OIDType NOT NULL PRIMARY KEY DEFAULT NEWID ( ), 
    [Code] CHAR(3) NOT NULL, 
    [ShortValue] VARCHAR(50) NOT NULL, 
    [LongValue] VARCHAR(200) NULL, 
    [EffectiveFromDate] DATETIME2 NOT NULL, 
    [EffectiveToDate] DATETIME2 NOT NULL, 
    [CategoryCode] CHAR(50) NOT NULL,
	[Active] BIT NOT NULL DEFAULT 1, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT GetDate(), 
    [CreatedBy] VARCHAR(50) NOT NULL DEFAULT SYSTEM_USER, 
	[RowVersion] ROWVERSION NOT NULL
    CONSTRAINT [AK_CodeSet_Column] UNIQUE ([Code],[CategoryCode])   
)

GO

CREATE INDEX [CategoryColumnIndex] ON [dbo].[CodeSet] ([CategoryCode])

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Primary key',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CodeSet',
    @level2type = N'COLUMN',
    @level2name = N'OID'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'code for this record',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CodeSet',
    @level2type = N'COLUMN',
    @level2name = N'Code'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'short value description of code',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CodeSet',
    @level2type = N'COLUMN',
    @level2name = N'ShortValue'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'long value description of code',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CodeSet',
    @level2type = N'COLUMN',
    @level2name = N'LongValue'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'the effective from date of validity',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CodeSet',
    @level2type = N'COLUMN',
    @level2name = N'EffectiveFromDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'the effective to date until this value is valid',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CodeSet',
    @level2type = N'COLUMN',
    @level2name = N'EffectiveToDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'category this record belogs to',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CodeSet',
    @level2type = N'COLUMN',
    @level2name = N'CategoryCode'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'whether or not this record is active',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CodeSet',
    @level2type = N'COLUMN',
    @level2name = N'Active'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'date when this record created',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CodeSet',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'who created this record',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CodeSet',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Unique Row version for the record',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CodeSet',
    @level2type = N'COLUMN',
    @level2name = N'RowVersion'