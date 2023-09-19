BEGIN
	INSERT INTO dbo.tblMuzzleType (id, description) VALUES
	(NEWID(), 'narrow'),
	(NEWID(), 'normal'),
	(NEWID(), 'broad')
END