BEGIN
	INSERT INTO dbo.tblLegLength (id, description) VALUES
	(NEWID(), 'short'),
	(NEWID(), 'medium'),
	(NEWID(), 'long')
END