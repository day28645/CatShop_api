using System;
using System.Collections.Generic;

namespace CatShop_api.Models;

public partial class Breed
{
    public Guid Breedid { get; set; }

    public string? Breedname { get; set; }

    public virtual ICollection<Cat> Cats { get; set; } = new List<Cat>();
}
