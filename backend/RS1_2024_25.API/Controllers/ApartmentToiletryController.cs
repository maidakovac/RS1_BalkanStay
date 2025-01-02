using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RS1_2024_25.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ApartmentToiletryController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;

        public ApartmentToiletryController(ApplicationDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }

        [HttpGet]
        public ActionResult<List<ApartmentToiletry>> Get()
        {
            var apartmentToiletries = _DbContext.ApartmentToiletries.ToList();

            if (apartmentToiletries == null)
            {
                return BadRequest();
            }

            return Ok(apartmentToiletries);
        }

        [HttpGet("{ApartmentToiletryId}")]
        public ActionResult<ApartmentToiletry> GetById(int ApartmentToiletryId)
        {
            var apartmentToiletry = _DbContext.ApartmentToiletries.Find(ApartmentToiletryId);

            if (apartmentToiletry == null)
            {
                return BadRequest();
            }

            return Ok(apartmentToiletry);
        }

        [HttpDelete("{ApartmentToiletryId}")]
        public ActionResult Delete(int ApartmentToiletryId)
        {
            var apartmentToiletry = _DbContext.ApartmentToiletries.Find(ApartmentToiletryId);

            if (apartmentToiletry == null)
            {
                return BadRequest();
            }

            _DbContext.ApartmentToiletries.Remove(apartmentToiletry);
            _DbContext.SaveChanges();

            return Ok();
        }

        [HttpPost] /// INSERT
        public ActionResult Insert(ApartmentToiletryInsertVM apartmentToiletry)
        {
            var newApartmentToiletry = new ApartmentToiletry()
            {
                ApartmentId=apartmentToiletry.ApartmentId,
                ToiletryID=apartmentToiletry.ToiletryID
            };

            _DbContext.ApartmentToiletries.Add(newApartmentToiletry);
            _DbContext.SaveChanges();

            return Ok(newApartmentToiletry);
        }

        [HttpPut] ///UPDATE
        public ActionResult Update(ApartmentToiletryUpdateVM apartmentToiletry)
        {
            var updatedApartmentToiletry = _DbContext.ApartmentToiletries.Find(apartmentToiletry.ApartmentToiletryID);

            if (updatedApartmentToiletry == null)
            {
                return BadRequest();
            }

            updatedApartmentToiletry.ApartmentId = apartmentToiletry.ApartmentId;
            updatedApartmentToiletry.ToiletryID = apartmentToiletry.ToiletryID;

            _DbContext.ApartmentToiletries.Update(updatedApartmentToiletry);
            _DbContext.SaveChanges();

            return Ok();
        }

    }

}
