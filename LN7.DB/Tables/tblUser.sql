CREATE TABLE [dbo].[tblUser]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Username] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(12) NOT NULL, 
    [First_Name] VARCHAR(50) NOT NULL, 
    [Last_Name] VARCHAR(50) NOT NULL, 
    [Date_Created] DATETIME NOT NULL, 
    [Email] VARCHAR(50) NOT NULL, 
    [Is_Admin] BIT NOT NULL
)
