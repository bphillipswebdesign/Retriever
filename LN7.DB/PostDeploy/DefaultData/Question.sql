BEGIN

	INSERT INTO tblQuestion(Id, Question, Trait_Id,Answer) VALUES

	(1, 'Does your mystery dog have shorter ears?',1,1),
	(2, 'Does your mystery dog have medium ears?',1,2),
	(3, 'Does your mystery dog have longer ears?',1,3),

	(4, 'Does your dog have upright ears?',2,1),
	(5, 'Does your dog have droopy ears?',2,2),

	(6, 'Is the dog you''re thinking of a slim dog?',3,1),
	(7, 'Does your mystery dog have a normal build?',3,2),
	(8, 'Is the dog you are thinking of a muscular dog?',3,3),

	(9, 'Does your mystery dog''s tail normally curled up?',4,1),
	(10, 'Does your mystery dog''s tail normally straight?',4,2),
	(11, 'Does your mystery dog''s tail normally sickle-shaped?',4,3),

	(12, 'Does the dog you''re thinking of have a shorter tail?',5,1),
	(13, 'Does the dog you''re thinking of have a medium length tail?',5,2),
	(14, 'Does the dog you''re thinking of have a longer tail?',5,3),

	--(15, 'What is the origin of your dog: China?',6,1),
	--(16, 'What is the origin of your dog: England?',6,2),
	--(17, 'What is the origin of your dog: Germany?',6,3),
	--(18, 'What is the origin of your dog: the UK?',6,4),
	--(19, 'What is the origin of your dog: the US?',6,5),

	(15, 'Is your mystery dog''s muzzle narrow?',6,1),
	(16, 'Is your mystery dog''s muzzle standard width?',6,2),
	(17, 'Is your mystery dog''s muzzle broad?',6,3),

	(18, 'Does the dog you''re thinking of have a shorter muzzle?',7,1),
	(19, 'Does the dog you''re thinking of have a medium muzzle?',7,2),
	(20, 'Does the dog you''re thinking of have a longer muzzle?',7,3),

	(21, 'Does the dog you''re thinking of have shorter legs?',8,1),
	(22, 'Does the dog you''re thinking of have medium-length legs?',8,2),
	(23, 'Does the dog you''re thinking of have longer legs?',8,3),

	(24, 'Is your mystery dog''s hair Curly?',9,1),
	(25, 'Is your mystery dog''s hair Flat?',9,2),
	(26, 'Is your mystery dog''s hair Wiry?',9,3),
	(27, 'Is your mystery dog''s hair Wavy?',9,4),
	(28, 'Is your mystery dog''s hair Fluffy?',9,5),

	(29, 'Is your mystery dog''s hair shorter than most dogs?',10,1),
	(30, 'Is your mystery dog''s hair medium length?',10,2),
	(31, 'Is your mystery dog''s hair longer than most dogs?',10,3),

	(32, 'Is the hair of the dog you''re thinking of a single color?',11,1),
	(33, 'Is the hair of the dog you''re thinking of two colors?',11,2),
	(34, 'Is your mystery dog''s hair three or more colors?',11,3),
	(35, 'Does your mystery dog''s hair have patterns?',11,4),

	(36, 'Is your mystery dog a Sporting dog?',12,1),
	(37, 'Is your mystery dog a Non-sporting dog?',12,2),
	(38, 'Is your mystery dog a Hound dog?',12,3),
	(39, 'Is your mystery dog a Herding dog?',12,4),
	(40, 'Is your mystery dog a Terrier dog?',12,5),
	(41, 'Is your mystery dog a Toy dog?',12,6),
	(42, 'Is your mystery dog a Working dog?',12,7);
END;
