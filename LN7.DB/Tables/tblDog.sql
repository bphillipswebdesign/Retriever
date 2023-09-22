CREATE TABLE [dbo].[tblDog]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [BreedName] VARCHAR(50) NOT NULL,
    [Imagepath] VARCHAR(250) NOT NULL,
    [DogGroup] INT NOT NULL,
    [CoatColor] INT NOT NULL,
    [CoatType] INT NOT NULL,
    [CoatLength] INT NOT NULL, 
    [EarType] INT NOT NULL, 
    [EarLength] INT NOT NULL, 
    [LegLength] INT NOT NULL, 
    [BodyType] INT NOT NULL, 
    [MuzzleType] INT NOT NULL,
    [MuzzleLength] INT NOT NULL,
    [Origin] INT NULL,
    [TailType] INT NOT NULL,
    [TailLength] INT NOT NULL,
    [WeightClass] INT NOT NULL
)
