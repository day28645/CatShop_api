using CatShop_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatShop_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BreedsController : Controller
    {
        private CatshopDbContext _context;
        public BreedsController(CatshopDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBreeds()
        {
            var breeds = _context.Breeds.ToList();

            return Ok(breeds);
        }
        
    }
}
