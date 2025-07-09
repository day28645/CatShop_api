using CatShop_api.APIModel;
using CatShop_api.Models;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult GetUsers()
        {
            //var user = _context.Users.ToList();
            var linqUser = (from s in _context.Users select s).ToList();

            return Ok(linqUser);
        }

        [HttpGet("{id}")]
        public IActionResult GetUsers(Guid id)
        {
            var checkUser = _context.Users.Find(id);
            if (checkUser == null)
            {
                return NotFound();
            }
            return Ok(checkUser);
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser(UsersRequestModel usersRequest)
        {
            var checkUser = _context.Users.FirstOrDefault(c => c.Username == usersRequest.UserName);
            if (checkUser != null)
            {
                ModelState.AddModelError("Username", "Username is already used");
                var validation = new ValidationProblemDetails(ModelState);
                return Ok(validation);
            }

            AESOparation aESOparation = new AESOparation();
            var passwordhash = aESOparation.HashPasword(usersRequest.Password, out var salt);
            Console.WriteLine($"Password hash: {passwordhash}");
            Console.WriteLine($"Generated salt: {Convert.ToHexString(salt)}");


            var userCreate = new User
            {
                Userid = Guid.NewGuid(),
                Username = usersRequest.UserName,
                Firstname = usersRequest.Firstname,
                Lastname = usersRequest.Lastname,
                //Password = usersRequest.Password,
                Email = usersRequest.Email,
                Address = usersRequest.Address,
                Phone = usersRequest.Phone,
                Birthdate = usersRequest.Birthdate,
                Createby = usersRequest.UserName,
                Gender = usersRequest.Gender,
                Modifiedby = null,
                PasswordHash = passwordhash,
                PasswordSalt = salt,

            };

            _context.Users.Add(userCreate);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return Ok("Create Success");
            }
            else
            {
                return BadRequest();
            }
           // return Ok();
        }

    }
}
