using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;

namespace RS1_2024_25.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _DbContext;


        public CityController(ApplicationDbContext _DbContext)
        {

            this._DbContext = _DbContext;
        }



        [HttpGet]

        public ActionResult<List<City>> Get()
        {
            var cities = _DbContext.Cities.ToList();

            if (cities == null)
            {
                return BadRequest();
            }


            return Ok(cities);
        }

    }
}
