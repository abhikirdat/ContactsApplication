# ContactsApplication


# Project Title

Contacts Application

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

What things you need to install the software and how to install them

```
visual studio 2013
SQL Server
``


## Deployment

Add additional notes about how to deploy this on a live system



## Database
 Database Query in case create new database and connection string
 Add connection string in web.config
 <add name="ConnectionString" connectionString="Data Source=(localdb)\Projects;Initial Catalog=ContactsInfo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" providerName="System.Data.SqlClient" />

------------Create Table script-------------------------------

CREATE TABLE [dbo].[Contacts] (
    [ContactID]    INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (50) NOT NULL,
    [LastName]     NVARCHAR (50) NOT NULL,
    [EmailID]      NVARCHAR (50) NOT NULL,
    [MobileNumber] NVARCHAR (50) NOT NULL,
    [Status]       BIT           NOT NULL
);
-----------Create Table script end----------------------------

---------- Insert data store procedure script-----------------

CREATE PROCEDURE [dbo].[sp_add_contact_I]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@EmailID nvarchar(50),
	@MobileNumber nvarchar(50),
	@Status bit
AS
	INSERT INTO Contacts(FirstName,LastName,EmailID,MobileNumber,[Status])
	VALUES(@FirstName,@LastName,@EmailID,@MobileNumber,@Status)
RETURN 0

CREATE PROCEDURE [dbo].[sp_update_contact_U]
	@ContactID int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@EmailID nvarchar(50),
	@MobileNumber nvarchar(50),
	@Status bit
AS
	UPDATE
	 Contacts
	 SET
	  FirstName=@FirstName,
	  LastName=@LastName,
	  EmailID=@EmailID,
	  MobileNumber=@MobileNumber,
	  [Status]=@Status
	  WHERE ContactID=@ContactID
RETURN 0
--------------- Insert data store procedure script End---------------------------

---------------- Get data by id store procedure script---------------------------
CREATE PROCEDURE [dbo].[sp_get_contact_by_id]
	@ContactID int 
AS
	SELECT * from Contacts
	WHERE ContactID=@ContactID
RETURN 0
-----------------get data by id store procedure script End-----------------------

---------------- List all data store procedure script----------------------------

CREATE PROCEDURE [dbo].[sp_get_contact_L]
	 
AS
	Select * from Contacts
RETURN 0
 
---------------- List all data store procedure script End------------------------


---------------- delete data by id store procedure script------------------------
CREATE PROCEDURE [dbo].[sp_update_contact_D]
	@ContactID int	 
AS
	DELETE FROM Contacts
	WHERE ContactID=@ContactID
RETURN 0
---------------- delete data by id store procedure script End--------------------




## Authors

**Abhijit Kirdat**
