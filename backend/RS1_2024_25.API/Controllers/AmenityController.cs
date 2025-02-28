using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RS1_2024_25.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AmenityController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;

        public AmenityController(ApplicationDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }

        [HttpGet]
        public ActionResult<List<Amenity>> Get()
        {
            var amenities = _DbContext.Amenities
                                        .Include(x=>x.ApartmentAmenities)
                                        .ToList();

            if (amenities == null)
            {
                return BadRequest();
            }

            return Ok(amenities);
        }

        [HttpGet("{AmenityId}")]
        public ActionResult<Amenity> GetById(int AmenityId)
        {
            var amenity = _DbContext.Amenities.Find(AmenityId);

            if (amenity == null)
            {
                return BadRequest();
            }

            return Ok(amenity);
        }

        [HttpDelete("{AmenityId}")]
        public ActionResult Delete(int AmenityId)
        {
            var amenity = _DbContext.Amenities.Find(AmenityId);

            if (amenity == null)
            {
                return BadRequest();
            }

            _DbContext.Amenities.Remove(amenity);
            _DbContext.SaveChanges();

            return Ok();
        }

        [HttpPost] /// INSERT
        public ActionResult Insert(AmenityInsertVM amenity)
        {
            var newAmenity = new Amenity()
            {
                AmenityText = amenity.AmenityText,
            };

            _DbContext.Amenities.Add(newAmenity);
            _DbContext.SaveChanges();

            return Ok(newAmenity);
        }

        [HttpPut] ///UPDATE
        public ActionResult Update(AmenityUpdateVM amenity)
        {
            var updatedAmenity = _DbContext.Amenities.Find(amenity.AmenityID);

            if (updatedAmenity == null)
            {
                return BadRequest();
            }

            updatedAmenity.AmenityID = amenity.AmenityID;
            updatedAmenity.AmenityText = amenity.AmenityText;

            _DbContext.Amenities.Update(updatedAmenity);
            _DbContext.SaveChanges();

            return Ok();
        }

    }
}
