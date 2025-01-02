using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;

namespace RS1_2024_25.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _DbContext;


        public CountryController(ApplicationDbContext _DbContext)
        {

            this._DbContext = _DbContext;
        }

        [HttpGet]

        public ActionResult<List<Country>> Get()
        {
            var countries = _DbContext.Countries.ToList();

            if (countries == null)
            {
                return BadRequest();
            }


            return Ok(countries);
        }




        [HttpGet("{CountryId}")]

        public ActionResult<Country> GetById(int CountryId)
        {
            var country = _DbContext.Countries.Find(CountryId);

            if (country == null)
            {
                return BadRequest();
            }

            return Ok(country);
        }


    }
}
