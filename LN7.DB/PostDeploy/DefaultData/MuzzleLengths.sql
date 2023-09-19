BEGIN
	INSERT INTO dbo.tblMuzzleLength (id, description) VALUES
	(NEWID(), 'short'),
	(NEWID(), 'medium'),
	(NEWID(), 'long')
END