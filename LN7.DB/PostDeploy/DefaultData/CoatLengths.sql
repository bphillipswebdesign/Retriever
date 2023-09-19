BEGIN
	INSERT INTO dbo.tblCoatLength (id, description) VALUES
	(NEWID(), 'short'),
	(NEWID(), 'medium'),
	(NEWID(), 'long')
END