BEGIN
	INSERT INTO dbo.tblTailType (id, description) VALUES
	(NEWID(), 'curl up'),
	(NEWID(), 'straight'),
	(NEWID(), 'sickle')
END