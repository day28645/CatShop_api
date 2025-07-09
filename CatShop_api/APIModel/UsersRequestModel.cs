namespace CatShop_api.APIModel
{
    public class UsersRequestModel
    {
        public string? UserName { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public DateOnly? Birthdate { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? Gender { get; set; }
    }

}
