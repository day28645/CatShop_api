using CatShop_api.APIModel;
using CatShop_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace CatShop_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : Controller
    {
        private readonly CatshopDbContext _context;
        private  IConfiguration _config;
        public CatsController(CatshopDbContext context, IConfiguration configuration)
        {
            _context = context;
            _config = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetCats()
        {
            var cat = await _context.Cats.Where(c => c.CatStatus == "avaliable").ToListAsync();
            return Ok(cat);
        }

        [HttpPost("CreateCat")]
        public async Task<IActionResult> CreateCat([FromForm] AddCatsRequestModel catsRequest)
        {
            var checkCat = _context.Cats.FirstOrDefault(c => c.Idnumber == catsRequest.Idnumber);
            if (checkCat != null)
            {
                ModelState.AddModelError("ID Number", "ID Number is already used");
                var validation = new ValidationProblemDetails(ModelState);
                return Ok(validation);
            }
            var saveDirectory = _config["imagepath"];

            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }
            var imagename = catsRequest.image.FileName;
            string fileSavePath = Path.Combine(saveDirectory, imagename);
            await using (var stem = System.IO.File.Create(fileSavePath)) 
            {
                await catsRequest.image.CopyToAsync(stem);
            }

            var catCreate = new Cat
            {
                Catid = Guid.NewGuid(),
                Birthdate = catsRequest.Birthdate,
                Gender = catsRequest.Gender,
                Price = catsRequest.Price,
                Catdetails = catsRequest.Catdetails,
                Size = catsRequest.Size,
                Idnumber = catsRequest.Idnumber,
                Breedid = Guid.Parse(catsRequest.Breedid),
                ImagePath = fileSavePath,
                Images = imagename,
                CatStatus = catsRequest.CatStatus,
                CatName = catsRequest.CatName
            };

            _context.Cats.Add(catCreate);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return Ok("Create Success");
            }
            else
            {
                return BadRequest();
            }
         
        }
    }
}
