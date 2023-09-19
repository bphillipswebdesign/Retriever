BEGIN
	INSERT INTO dbo.tblTailLength (id, description) VALUES
	(NEWID(), 'short'),
	(NEWID(), 'medium'),
	(NEWID(), 'long')
END