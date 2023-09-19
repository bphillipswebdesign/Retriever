BEGIN
	INSERT INTO dbo.tblDogGroup (id, description) VALUES
	(NEWID(), 'sporting'),
	(NEWID(), 'non-sporting'),
	(NEWID(), 'hound'),
	(NEWID(), 'herding'),
	(NEWID(), 'terrier'),
	(NEWID(), 'toy'),
	(NEWID(), 'working')
END