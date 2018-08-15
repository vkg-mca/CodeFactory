/*
The database must have a MEMORY_OPTIMIZED_DATA filegroup
before the memory optimized object can be created.

The bucket count should be set to about two times the 
maximum expected number of distinct values in the 
index key, rounded up to the nearest power of two.
*/

CREATE TABLE [dbo].[Employer]
(
	[OID] OIDType NOT NULL PRIMARY KEY DEFAULT NEWID ( ), 
    [Name] VARCHAR(100) NOT NULL, 
    [Address] VARCHAR(500) NOT NULL, 
    [ContactNumber] VARCHAR(50) NULL, 
    [EmploymentFromDate] DATETIME2 NOT NULL, 
    [EmploymentToDate] DATETIME2 NOT NULL, 
    [Designation] VARCHAR(100) NOT NULL,
	[YearlyFixedSalary] DECIMAL NOT NULL DEFAULT 0.0,
	[YearlyVariableSalary] DECIMAL NOT NULL DEFAULT 0.0,
	[ManagerName] VARCHAR(100) NOT NULL,
	[ManagerEmail] VARCHAR(100) NOT NULL,
	[ManagerContact] VARCHAR(100) NOT NULL,
	[HRName] VARCHAR(100) NOT NULL,
	[HREmail] VARCHAR(100) NOT NULL,
	[HRContact] VARCHAR(100) NOT NULL,
	[ReasonForChange] VARCHAR(1000) NULL,
	[Active] BIT NOT NULL DEFAULT 1, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT GetDate(), 
    [CreatedBy] VARCHAR(50) NOT NULL DEFAULT SYSTEM_USER, 
	[RowVersion] ROWVERSION NOT NULL
) 