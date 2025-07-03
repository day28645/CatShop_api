using System.ComponentModel.DataAnnotations.Schema;

namespace CatShop_api.Models
{
    public class Login
    {
        public Guid Loginid { get; set; }

        public DateTime LoginDateTime { get; set; }
        public DateTime LogoutDateTime { get; set; }

        [ForeignKey("User")]
        public string Userid { get; set; }
    }
}
