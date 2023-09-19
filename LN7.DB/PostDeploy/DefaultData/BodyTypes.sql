BEGIN
	INSERT INTO dbo.tblBodyType (id, description) VALUES
	(NEWID(), 'slim'),
	(NEWID(), 'normal'),
	(NEWID(), 'muscular')
END