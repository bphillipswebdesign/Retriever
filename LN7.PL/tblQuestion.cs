namespace LN7.PL;

public partial class tblQuestion
{
    public int Id { get; set; }

    public string Question { get; set; } = null!;
    public int Trait_Id { get; set; }
    public int Answer { get; set; }
}