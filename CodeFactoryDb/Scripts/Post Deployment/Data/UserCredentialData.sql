DECLARE @UserOID uniqueidentifier
DECLARE @UserStatus uniqueidentifier
SELECT @UserStatus=OID FROM CodeSet where CategoryCode='STATUS' and Code='ACT'
SELECT @UserOID=OID FROM [dbo].[User] where FirstName='Vinod' AND LastName='Gupta'

INSERT INTO [dbo].[UserCredential] ( [UserOID] ,[Password],	[StatusOID] ) VALUES
(@UserOID,dbo.Encrypt('vinod') ,@UserStatus)