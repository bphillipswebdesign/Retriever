/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

DROP TABLE IF EXISTS dbo.tblBodyType
DROP TABLE IF EXISTS dbo.tblCoatColor
DROP TABLE IF EXISTS dbo.tblCoatLength
DROP TABLE IF EXISTS dbo.tblCoatType
DROP TABLE IF EXISTS dbo.tblDog
DROP TABLE IF EXISTS dbo.tblDogGroup
DROP TABLE IF EXISTS dbo.tblEarLength
DROP TABLE IF EXISTS dbo.tblEarType
DROP TABLE IF EXISTS dbo.tblLegLength
DROP TABLE IF EXISTS dbo.tblMuzzleLength
DROP TABLE IF EXISTS dbo.tblMuzzleType
DROP TABLE IF EXISTS dbo.tblOrigin
DROP TABLE IF EXISTS dbo.tblTailLength
DROP TABLE IF EXISTS dbo.tblTailType
DROP TABLE IF EXISTS dbo.tblUser
DROP TABLE IF EXISTS dbo.tblWeightClass