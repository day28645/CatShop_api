using System;
using System.Collections.Generic;

namespace CatShop_api.Models;

public partial class Users
{
    public Guid Userid { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Username { get; set; }

    public DateTime? Birthdate { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Createby { get; set; }

    public string? Modifiedby { get; set; }

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();
}
