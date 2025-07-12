namespace CatShop_api.APIModel
{
    public class AddCatsRequestModel
    {
        public IFormFile? image { get; set; }

        public string? Idnumber { get; set; }

        public DateOnly? Birthdate { get; set; }

        public string? Gender { get; set; }

        public double? Price { get; set; }

        public string? Catdetails { get; set; }

        public string? Size { get; set; }

        public string? Breedid { get; set; }

        public string? CatStatus { get; set; }

        public string? CatName { get; set; }
    }

    public class AddCatsResponseMOdel
    {
        public string? Idnumber { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Gender { get; set; }

        public double? Price { get; set; }

        public string? Catdetails { get; set; }

        public string? Size { get; set; }

        public string? Images { get; set; }

        public Guid? Breedid { get; set; }

        public string? CatStatus { get; set; }

        public string? CatName { get; set; }
    }
}
