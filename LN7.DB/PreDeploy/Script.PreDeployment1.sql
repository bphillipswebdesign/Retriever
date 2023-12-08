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

DROP TABLE IF EXISTS tblBodyType
DROP TABLE IF EXISTS tblCoatColor
DROP TABLE IF EXISTS tblCoatLength
DROP TABLE IF EXISTS tblCoatType
DROP TABLE IF EXISTS tblDog
DROP TABLE IF EXISTS tblDogGroup
DROP TABLE IF EXISTS tblEarLength
DROP TABLE IF EXISTS tblEarType
DROP TABLE IF EXISTS tblLegLength
DROP TABLE IF EXISTS tblMuzzleLength
DROP TABLE IF EXISTS tblMuzzleType
DROP TABLE IF EXISTS tblTailLength
DROP TABLE IF EXISTS tblTailType
DROP TABLE IF EXISTS tblUser
DROP TABLE IF EXISTS tblWeightClass
DROP TABLE IF EXISTS tblQuestion
DROP TABLE IF EXISTS tblPlayerStat