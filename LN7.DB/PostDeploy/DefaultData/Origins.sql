BEGIN
	INSERT INTO dbo.tblOrigin (id, description) VALUES
	(NEWID(), 'china'),
	(NEWID(), 'england'),
	(NEWID(), 'german'),
	(NEWID(), 'uk'),
	(NEWID(), 'us')
END