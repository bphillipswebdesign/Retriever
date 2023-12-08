CREATE TABLE [dbo].[tblQuestion]
(
	[Id] INT NOT NULL PRIMARY KEY, 
	[Question] VARCHAR(250) NOT NULL, 
    [Trait_Id] INT NOT NULL, 
    [Answer] INT NOT NULL
)
