using CatShop_api.APIModel;
using CatShop_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatShop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : Controller
    {
        private readonly CatshopDbContext _context;

        public LoginsController(CatshopDbContext context)
        {
            _context = context;
        }

        [HttpPost("LoginUser")]
        public IActionResult UserLogin(LoginsRequestModel loginsRequest)
        {
            var loginResponse = new LoginResponseModel();

            if (string.IsNullOrEmpty(loginsRequest.Password))
            {
                loginResponse.IsSuceess = false;
                loginResponse.message = "password is Empty";
                return Ok(loginResponse);
            }
            if (string.IsNullOrEmpty(loginsRequest.UserName))
            {
                loginResponse.IsSuceess = false;
                loginResponse.message = "UserName is Empty";
                return Ok(loginResponse);
            }
            var userlogin = _context.Users.SingleOrDefault(x => x.Username == loginsRequest.UserName);
            if (userlogin == null) { return Unauthorized(); }


            AESOparation aESOparation = new AESOparation();
            var result = aESOparation.VerifyPassword(loginsRequest.Password, userlogin.PasswordHash, userlogin.PasswordSalt);
            if (result)
            {
                
                //var userid = userlogin.Select(x => x.Userid).FirstOrDefault();

                loginResponse.IsSuceess = true;
                loginResponse.message = "Login success";
                loginResponse.UserName = loginsRequest.UserName;
                loginResponse.Userid = userlogin.Userid.ToString();


                var loginCreate = new Login
                {
                    Loginid = Guid.NewGuid(),
                    LoginDateTime = DateTime.Now,
                    Userid = userlogin.Userid,
                };
             
                _context.Login.Add(loginCreate);
                var resultSaveLogin = _context.SaveChanges();
                if (resultSaveLogin == 0)
                {
                    loginResponse.IsSuceess = false;
                    loginResponse.message = "insert log Login Fail";
                }

                loginResponse.token = JWT_Services.Genaratoken(userlogin.Username);
               
            }
 



            return Ok(loginResponse);

        }
    }
}
