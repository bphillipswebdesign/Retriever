CREATE TABLE [dbo].[tblDog]
(
	[dog_id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [breed] VARCHAR(20) NOT NULL, 
    [weight] INT NOT NULL, 
    [image] IMAGE NOT NULL, 
    [german_orgin] BIT NOT NULL, 
    [fluffy_fur] BIT NOT NULL, 
    [flat_face] BIT NOT NULL, 
    [pointy_ears] BIT NOT NULL, 
    [short_legs] BIT NOT NULL, 
    [one_color] BIT NOT NULL, 
    [two_color] BIT NOT NULL, 
    [black] BIT NOT NULL, 
    [white] BIT NOT NULL, 
    [golden] BIT NOT NULL, 
    [curly_fur] BIT NOT NULL, 
    [china_orgin] BIT NOT NULL, 
    [curly_tail] BIT NOT NULL, 
    [straight_tail] BIT NOT NULL, 
    [crossbred] BIT NOT NULL,

)
