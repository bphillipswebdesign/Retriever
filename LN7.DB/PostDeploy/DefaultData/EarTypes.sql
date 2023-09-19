BEGIN
	INSERT INTO dbo.tblEarType (id, description) VALUES
	(NEWID(), 'upright'),
	(NEWID(), 'droopy'),
	(NEWID(), '')
END