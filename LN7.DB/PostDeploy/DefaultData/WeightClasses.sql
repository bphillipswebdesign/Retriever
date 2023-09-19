BEGIN
	INSERT INTO dbo.tblWeightClass (id, description) VALUES
	(NEWID(), '<12lbs'),
	(NEWID(), '13lbs<>24lbs'),
	(NEWID(), '25lbs<>59lbs'),
	(NEWID(), '60lbs<>99lbs'),
	(NEWID(), '>100lbs')
END