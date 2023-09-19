CREATE TABLE [dbo].[tblDog]
(
	[id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [breedname] VARCHAR(50) NOT NULL,
    [imagepath] VARCHAR(250) NOT NULL,
    [doggroup] INT NOT NULL,
    [coatcolor] INT NOT NULL,
    [coattype] INT NOT NULL,
    [coatlength] INT NOT NULL, 
    [eartype] INT NOT NULL, 
    [earlength] INT NOT NULL, 
    [leglength] INT NOT NULL, 
    [bodytype] INT NOT NULL, 
    [muzzletype] INT NOT NULL,
    [muzzlelength] INT NOT NULL,
    [origin] INT NULL,
    [tailtype] INT NOT NULL,
    [taillength] INT NOT NULL,
    [weightclass] INT NOT NULL
)
