DECLARE @GenderStatus uniqueidentifier
DECLARE @RecordStatus uniqueidentifier
SELECT @GenderStatus=OID FROM CodeSet where CategoryCode='GENDER' and Code='MLE'
SELECT @RecordStatus=OID FROM CodeSet where CategoryCode='STATUS' and Code='ACT'

INSERT INTO [dbo].[User] ([UserName],[Title] ,[FirstName],[MiddleName],[LastName],[GenderOID],[DateOfBirth],[StatusOID]) VALUES
('VGupta','Mr.','Vinod','Kumar','Gupta',@GenderStatus,'1972-04-15',@RecordStatus),
('JLowy','Mr.','Juval','','Lowee',@GenderStatus,'1965-07-28',@RecordStatus)