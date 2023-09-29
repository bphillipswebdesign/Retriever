BEGIN

	INSERT INTO tblQuestion(Id, Question, Trait_Id,Answer) VALUES

	(1, 'Does your dog have short ears?',1,1),
	(2, 'Does your dog have medium ears?',1,2),
	(3, 'Does your dog have long ears?',1,3),

	(4, 'Does your dog have upright ears?',2,1),
	(5, 'Does your dog have droopy ears?',2,2),

	(6, 'Is your dog slim?',3,1),
	(7, 'Is your dog of normal build?',3,2),
	(8, 'Is your dog muscular?',3,3),

	(9, 'Does your dog''s tail curl up?',4,1),
	(10, 'Is your dog''s tail straight?',4,2),
	(11, 'Does your dog''s tail sickle-shaped?',4,3),

	(12, 'Does your dog have a short tail?',5,1),
	(13, 'Does your dog have a medium length tail?',5,2),
	(14, 'Is your dog''s tail long?',5,3),

	(15, 'What is the origin of your dog: China?',6,1),
	(16, 'What is the origin of your dog: England?',6,2),
	(17, 'What is the origin of your dog: Germany?',6,3),
	(18, 'What is the origin of your dog: the UK?',6,4),
	(19, 'What is the origin of your dog: the US?',6,5),

	(20, 'Is your dog''s muzzle narrow?',7,1),
	(21, 'Is your dog''s muzzle of normal width?',7,2),
	(22, 'Is your dog''s muzzle broad?',7,3),

	(23, 'Is your dog''s muzzle short?',8,1),
	(24, 'Is your dog''s muzzle of medium length?',8,2),
	(25, 'Is your dog''s muzzle long?',8,3),

	(26, 'Does your dog have short legs?',9,1),
	(27, 'Does your dog have medium-length legs?',9,2),
	(28, 'Does your dog have long legs?',9,3),

	(29, 'What type of coat does your dog have: Curly?',10,1),
	(30, 'What type of coat does your dog have: Flat?',10,2),
	(31, 'What type of coat does your dog have: Wiry?',10,3),
	(32, 'What type of coat does your dog have: Wavy?',10,4),
	(33, 'What type of coat does your dog have: Fluffy?',10,5),

	(34, 'Is your dog''s hair short?',11,1),
	(35, 'Is your dog''s hair of medium length?',11,2),
	(36, 'Is your dog''s hair long?',11,3),

	(37, 'Is your dog''s hair color: single color?',12,1),
	(38, 'Is your dog''s hair color: two colors?',12,2),
	(39, 'Is your dog''s hair color: three or more colors?',12,3),
	(40, 'Does your dog''s hair have any patterns?',12,4),

	(41, 'What type of dog is your dog: Sporting?',13,1),
	(42, 'What type of dog is your dog: Non-sporting?',13,2),
	(43, 'What type of dog is your dog: Hound?',13,3),
	(44, 'What type of dog is your dog: Herding?',13,4),
	(45, 'What type of dog is your dog: Terrier?',13,5),
	(46, 'What type of dog is your dog: Toy?',13,6),
	(47, 'What type of dog is your dog: Working?',13,7);
END;
