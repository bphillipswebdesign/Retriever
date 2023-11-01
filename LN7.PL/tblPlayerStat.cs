namespace LN7.PL;

public partial class tblPlayerStat
{
    public int Id { get; set; }

    public Guid UserId { get; set; }

    public DateTime PlayDate { get; set; }

    public bool Result { get; set; }
}