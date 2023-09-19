BEGIN
	INSERT INTO dbo.tblWeightClass (id, description) VALUES
	(1, '<12lbs'),
	(2, '13lbs<>24lbs'),
	(3, '25lbs<>59lbs'),
	(4, '60lbs<>99lbs'),
	(5, '>100lbs')
END