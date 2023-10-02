namespace LN7.PL;

public partial class tblUser
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string First_Name { get; set; } = null!;

    public string Last_Name { get; set; } = null!;

    public DateTime Date_Created { get; set; }

    public string Email { get; set; } = null!;

    public bool Is_Admin { get; set; }
}