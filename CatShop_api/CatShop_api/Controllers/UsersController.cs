using CatShop_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatShop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : Controller
    {
        private readonly CatshopDbContext _context; 
        public UsersController(CatshopDbContext context) 
        {         
            _context = context;
        }
        [HttpGet]
        public IActionResult GetUser()
        {
            //var user = _context.Users.ToList();
            var linqUser = (from s in _context.Users select s).ToList();
            
            return Ok(linqUser);
        }

        [HttpPost]
        public IActionResult CreateUser(User userDB)
        {
            var checkUser = _context.Users.FirstOrDefault(c => c.Phone == userDB.Phone);
            if (checkUser != null)
            {
                ModelState.AddModelError("Username", "Username is already used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            var user = new User
            {
                Userid = Guid.NewGuid(),
                Firstname = userDB.Firstname,
                Lastname = userDB.Lastname,
                Username = userDB.Username,
                Password = userDB.Password,
                Birthdate = userDB.Birthdate,
                Gender = userDB.Gender,
                Email = userDB.Email,
                Address = userDB.Address,
                Phone = userDB.Phone,
                Createby = userDB.Createby,

            };
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }
        
    }
}
