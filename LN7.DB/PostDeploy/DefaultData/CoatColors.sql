BEGIN
	INSERT INTO dbo.tblCoatColor (id, description) VALUES
	(NEWID(), 'solid'),
	(NEWID(), '2 colors'),
	(NEWID(), '3+ colors'),
	(NEWID(), 'any pattern')
END