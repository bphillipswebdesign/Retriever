using System;
using System.Collections.Generic;

namespace LN7.PL;

public partial class tblUser
{
    public Guid Id { get; set; }

    public string first_name { get; set; } = null!;

    public string last_name { get; set; } = null!;

    public string username { get; set; } = null!;

    public string password { get; set; } = null!;

    public string email { get; set; }

    public DateTime date_created { get; set; }

    public bool is_admin { get; set; }
}
