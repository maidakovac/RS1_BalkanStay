using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RS1_2024_25.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ApartmentAmenityController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;

        public ApartmentAmenityController(ApplicationDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }

        [HttpGet]
        public ActionResult<List<ApartmentAmenity>> Get()
        {
            var apartmentAmenities = _DbContext.ApartmentAmenities.ToList();

            if (apartmentAmenities == null)
            {
                return BadRequest();
            }

            return Ok(apartmentAmenities);
        }

        [HttpGet("{ApartmentAmenityId}")]
        public ActionResult<ApartmentAmenity> GetById(int ApartmentAmenityId)
        {
            var apartmentAmenity = _DbContext.ApartmentAmenities.Find(ApartmentAmenityId);

            if (apartmentAmenity == null)
            {
                return BadRequest();
            }

            return Ok(apartmentAmenity);
        }

        [HttpDelete("{ApartmentAmenityId}")]
        public ActionResult Delete(int ApartmentAmenityId)
        {
            var apartmentAmenity = _DbContext.ApartmentAmenities.Find(ApartmentAmenityId);

            if (apartmentAmenity == null)
            {
                return BadRequest();
            }

            _DbContext.ApartmentAmenities.Remove(apartmentAmenity);
            _DbContext.SaveChanges();

            return Ok();
        }

        [HttpPost] /// INSERT
        public ActionResult Insert(ApartmentAmenityInsertVM apartmentAmenity)
        {
            var newApartmentAmenity = new ApartmentAmenity()
            {
                ApartmentId=apartmentAmenity.ApartmentId,
                AmenityID=apartmentAmenity.AmenityID
            };

            _DbContext.ApartmentAmenities.Add(newApartmentAmenity);
            _DbContext.SaveChanges();

            return Ok(newApartmentAmenity);
        }

        [HttpPut] ///UPDATE
        public ActionResult Update(ApartmentAmenityUpdateVM apartmentAmenity)
        {
            var updatedApartmentAmenity = _DbContext.ApartmentAmenities.Find(apartmentAmenity.ApartmentAmenityID);

            if (updatedApartmentAmenity == null)
            {
                return BadRequest();
            }
            updatedApartmentAmenity.ApartmentAmenityID = apartmentAmenity.ApartmentAmenityID;
            updatedApartmentAmenity.ApartmentId = apartmentAmenity.ApartmentId;
            updatedApartmentAmenity.AmenityID = apartmentAmenity.AmenityID;

            _DbContext.ApartmentAmenities.Update(updatedApartmentAmenity);
            _DbContext.SaveChanges();

            return Ok();
        }

    }

}
