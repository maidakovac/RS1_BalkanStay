using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RS1_2024_25.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ApartmentImageController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;
        public ApartmentImageController(ApplicationDbContext _DbContext)
        {

            this._DbContext = _DbContext;
        }

        [HttpGet]

        public ActionResult<List<ApartmentImage>> Get()
        {
            var apartmentImages = _DbContext.ApartmentImages.Include(x => x.Image).ToList();

            if (apartmentImages == null)
            {
                return BadRequest();
            }


            return Ok(apartmentImages);
        }




        [HttpGet("{ApartmentImageId}")]

        public ActionResult<ApartmentImage> GetById(int ApartmentImageId)
        {
            var apartmentImage = _DbContext.ApartmentImages.Find(ApartmentImageId);

            if (apartmentImage == null)
            {
                return BadRequest();
            }

            return Ok(apartmentImage);
        }




        [HttpDelete("{ApartmentImageId}")]

        public ActionResult Delete(int ApartmentImageId)
        {
            var apartmentImage = _DbContext.ApartmentImages.Find(ApartmentImageId);

            if (apartmentImage == null)
            {
                return BadRequest();
            }

            _DbContext.ApartmentImages.Remove(apartmentImage);
            _DbContext.SaveChanges();

            return Ok();
        }




        [HttpPost] /// INSERT

        public ActionResult Insert(ApartmentImageInsertVM x)
        {
            var newApartmentImage = new ApartmentImage()
            {
                 ApartmentId=x.ApartmentId,
                 ImageID=x.ImageID
            };

            _DbContext.ApartmentImages.Add(newApartmentImage);
            _DbContext.SaveChanges();

            return Ok(newApartmentImage);
        }



        [HttpPut] ///UPDATE

        public ActionResult Update(ApartmentImageUpdateVM x)
        {
            var updatedApartmentImage = _DbContext.ApartmentImages.Find(x.ApartmentImageID);

            if (updatedApartmentImage == null)
            {
                return BadRequest();
            }

            updatedApartmentImage.ApartmentImageID=x.ApartmentImageID;
            updatedApartmentImage.ApartmentId=x.ApartmentImageID;
            updatedApartmentImage.ImageID=x.ImageID;

           _DbContext.ApartmentImages.Update(updatedApartmentImage);
            _DbContext.SaveChanges();

            return Ok();
        }
    }
}
