/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\DefaultData\BodyTypes.sql
:r .\DefaultData\CoatColors.sql
:r .\DefaultData\CoatLengths.sql
:r .\DefaultData\CoatTypes.sql
:r .\DefaultData\DogGroups.sql
:r .\DefaultData\Dogs.sql
:r .\DefaultData\EarLengths.sql
:r .\DefaultData\EarTypes.sql
:r .\DefaultData\LegLengths.sql
:r .\DefaultData\MuzzleLengths.sql
:r .\DefaultData\MuzzleTypes.sql
:r .\DefaultData\Origins.sql
:r .\DefaultData\TailLengths.sql
:r .\DefaultData\TailTypes.sql
:r .\DefaultData\Users.sql
:r .\DefaultData\WeightClasses.sql