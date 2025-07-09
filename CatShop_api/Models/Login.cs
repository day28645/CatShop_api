using CatShop_api.Models;

using System;
using System.Collections.Generic;

namespace CatShop_api.Models;

public partial class Login
{
    public Guid Loginid { get; set; }

    public DateTime? LoginDateTime { get; set; }

    public Guid? Userid { get; set; }

    public virtual User? Users { get; set; }
}
