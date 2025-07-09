namespace CatShop_api.APIModel
{
    public class LoginsRequestModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class LoginResponseModel
    {
        public string token { get; set; }

        public bool IsSuceess { get; set; }

        public string UserName { get; set; }

        public string Userid { get; set; }

        public string message {  get; set; }    
    }
}
