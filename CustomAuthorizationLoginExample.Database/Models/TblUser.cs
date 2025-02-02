using System;
using System.Collections.Generic;

namespace CustomAuthorizationLoginExample.Database.Models;

public partial class TblUser
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[] FullName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
