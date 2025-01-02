using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.ViewModel;
using static System.Net.Mime.MediaTypeNames;
using ImageEntity = RS1_2024_25.API.Data.Image;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RS1_2024_25.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ImageController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;


        public ImageController(ApplicationDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }



        [HttpGet]

        public ActionResult<List<ImageEntity>> Get()
        {
            var images = _DbContext.Images.ToList();

            if (images == null)
            {
                return BadRequest();
            }

            return Ok(images);
        }

        [HttpGet("{ImageID}")]
        public ActionResult<ImageEntity> GetById(int ImageID)
        {
            var images = _DbContext.Images.Find(ImageID);

            if (images == null)
            {
                return BadRequest();
            }

            return Ok(images);
        }




        [HttpDelete("{ImageID}")]

        public ActionResult Delete(int ImageID)
        {
            var image = _DbContext.Images.Find(ImageID);

            if (image == null)
            {
                return BadRequest();
            }

            _DbContext.Images.Remove(image);
            _DbContext.SaveChanges();

            return Ok();
        }




        [HttpPost] /// INSERT

        public ActionResult Insert(ImageInsertVM x)
        {
            var newImage = new ImageEntity()
            {
                Photo=x.Photo
            };

            _DbContext.Images.Add(newImage);
            _DbContext.SaveChanges();


            return Ok(newImage);
        }




        [HttpPut] ///UPDATE

        public ActionResult Update(ImageUpdateVM x)
        {
            var updatedImage = _DbContext.Images.Find(x.ImageID);

            if (updatedImage == null)
            {
                return BadRequest();
            }

            updatedImage.ImageID = x.ImageID;
            updatedImage.Photo= x.Photo;

            _DbContext.Images.Update(updatedImage);
            _DbContext.SaveChanges();

            return Ok(updatedImage);
        }
    }
}
