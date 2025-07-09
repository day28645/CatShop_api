using System;
using System.Collections.Generic;

namespace CatShop_api.Models;

public partial class Cat
{
    public Guid Catid { get; set; }

    public DateOnly? Birthdate { get; set; }

    public string? Gender { get; set; }

    public double? Price { get; set; }

    public string? Catdetails { get; set; }

    public string? Size { get; set; }

    public string? Images { get; set; }

    public Guid? Breedid { get; set; }

    public string? Idnumber { get; set; }

    public string? ImagePath { get; set; }

    public string? CatStatus { get; set; }
}
