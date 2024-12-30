using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.ViewModel;

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


        [HttpGet("{CityId}")]

        public ActionResult<City> GetById(int CityId)
        {
            var city = _DbContext.Apartments.Find(CityId);

            if (city == null)
            {
                return BadRequest();
            }

            return Ok(city);
        }




        [HttpDelete("{CityId}")]

        public ActionResult Delete(int CityId)
        {
            var city = _DbContext.Apartments.Find(CityId);

            if (city == null)
            {
                return BadRequest();
            }

            _DbContext.Apartments.Remove(city);
            _DbContext.SaveChanges();

            return Ok();
        }




        [HttpPost] /// INSERT

        public ActionResult Insert(CityInsertVM city)
        {
            var newCity = new City()
            {
                Name = city.Name,
                CountryId = city.CountryId,
            };

            _DbContext.Cities.Add(newCity);
            _DbContext.SaveChanges();


            return Ok(newCity);
        }




        [HttpPut] ///UPDATE

        public ActionResult Update(City city)
        {
            var updatedCity = _DbContext.Cities.Find(city.ID);

            if (updatedCity == null)
            {
                return BadRequest();
            }

            updatedCity.Name = city.Name;
            updatedCity.CountryId = city.CountryId;
            updatedCity.Apartments = city.Apartments;

            _DbContext.Cities.Update(updatedCity);
            _DbContext.SaveChanges();

            return Ok(updatedCity);
        }

    }
}
