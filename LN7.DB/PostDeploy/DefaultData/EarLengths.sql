BEGIN
	INSERT INTO dbo.tblEarLength (id, description) VALUES
	(NEWID(), 'short'),
	(NEWID(), 'medium'),
	(NEWID(), 'long')
END