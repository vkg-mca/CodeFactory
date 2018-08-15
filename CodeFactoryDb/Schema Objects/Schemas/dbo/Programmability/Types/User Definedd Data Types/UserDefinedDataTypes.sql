CREATE DEFAULT DefaultOID
AS NEWID()
GO

CREATE TYPE [dbo].[OIDType] FROM [uniqueidentifier] NOT NULL
GO

EXEC sys.sp_bindefault @defname=N'[dbo].[DefaultOID]', @objname=N'[dbo].[OIDType]' , @futureonly='futureonly'
GO

CREATE TYPE [dbo].[TransactionParameterType] AS TABLE(
	[Name]		[varchar](50) NOT NULL,
	[Type]		[varchar](50) NOT NULL,
	[Size]		[int] NULL,
	[Direction] [int] NOT NULL,
	[Nullable]	[int] NOT NULL,
	[Procedure] [varchar](50) NOT NULL,
	[Value]		[varchar](100) NOT NULL
)
GO

CREATE TYPE [dbo].[SecurityParameterType] AS TABLE(
	[UserName]		[varchar](50) NOT NULL,
	[OperationCode] [varchar](50) NOT NULL
)
GO