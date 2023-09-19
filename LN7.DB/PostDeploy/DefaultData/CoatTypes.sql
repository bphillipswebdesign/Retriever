BEGIN
	INSERT INTO dbo.tblCoatType (id, description) VALUES
	(NEWID(), 'curly'),
	(NEWID(), 'flat'),
	(NEWID(), 'wiry'),
	(NEWID(), 'wavy'),
	(NEWID(), 'fluffy')
END