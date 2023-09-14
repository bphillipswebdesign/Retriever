CREATE TABLE [dbo].[tblUser]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [username] VARCHAR(50) NOT NULL, 
    [password] VARCHAR(12) NOT NULL, 
    [first_name] VARCHAR(50) NOT NULL, 
    [last_name] VARCHAR(50) NOT NULL, 
    [date_created] DATETIME NOT NULL, 
    [email] VARCHAR(50) NOT NULL, 
    [is_admin] BIT NOT NULL
)
