BEGIN
	INSERT INTO dbo.tblUser VALUES
	(NEWID(), 'nharrison', 'pass', 'Nick', 'Harrison', GETDATE(), '500168115@fvtc.edu', 1),
	(NEWID(), 'bxiong', 'pass', 'Boonlert', 'Xiong', GETDATE(), '300076596@fvtc.edu', 1),
	(NEWID(), 'cneary', 'pass', 'Cael', 'Neary', GETDATE(), '300068580@fvtc.edu', 1),
	(NEWID(), 'skuhn', 'pass', 'Stephen', 'Kuhn', GETDATE(), '120191545@fvtc.edu', 1),
	(NEWID(), 'awheeler', 'pass', 'Alaina', 'Wheeler', GETDATE(), '300077752@fvtc.edu', 1),
	(NEWID(), 'bphillips', 'pass', 'Briana', 'Phillips', GETDATE(), '500146414@fvtc.edu', 1)
END