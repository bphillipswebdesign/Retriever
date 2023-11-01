declare @id1 uniqueidentifier;
declare @id2 uniqueidentifier;

select @id1 = Id from tblUser where Username = 'skuhn'
select @id2 = Id from tblUser where Username = 'bxiong'

BEGIN
	INSERT INTO tblPlayerStat VALUES (1,@id1,'01/02/2023',1)
	INSERT INTO tblPlayerStat VALUES (2,@id2,'02/03/2023',0)
END