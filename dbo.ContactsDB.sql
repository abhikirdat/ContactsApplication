CREATE TABLE [dbo].[Contacts]
(
	[ContactID] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [EmailID] NVARCHAR(50) NOT NULL, 
    [MobileNumber] NVARCHAR(50) NOT NULL, 
    [Status] BIT NOT NULL
)
