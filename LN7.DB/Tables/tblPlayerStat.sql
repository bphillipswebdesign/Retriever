CREATE TABLE [dbo].[tblPlayerStat]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [PlayDate] DATETIME NOT NULL, 
    [Result] BIT NOT NULL
)
