using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RS1_2024_25.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OwnerApartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;


        public OwnerApartmentController(ApplicationDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }



        [HttpGet]

        public ActionResult<List<OwnerApartment>> Get()
        {
            var ownerApartments = _DbContext.OwnerApartments.ToList();

            if (ownerApartments == null)
            {
                return BadRequest();
            }


            return Ok(ownerApartments);
        }

        [HttpGet("{OwnerApartmentID}")]

        public ActionResult<OwnerApartment> GetById(int OwnerApartmentID)
        {
            var ownerApartments = _DbContext.OwnerApartments.Find(OwnerApartmentID);

            if (ownerApartments == null)
            {
                return BadRequest();
            }

            return Ok(ownerApartments);
        }




        [HttpDelete("{OwnerApartmentID}")]

        public ActionResult Delete(int OwnerApartmentID)
        {
            var ownerApartment = _DbContext.OwnerApartments.Find(OwnerApartmentID);

            if (ownerApartment == null)
            {
                return BadRequest();
            }

            _DbContext.OwnerApartments.Remove(ownerApartment);
            _DbContext.SaveChanges();

            return Ok();
        }




        [HttpPost] /// INSERT

        public ActionResult Insert(OwnerApartmentInsertVM x)
        {
            var newOwnerApartment = new OwnerApartment()
            {
                OwnerID=x.OwnerID,
                ApartmentId=x.ApartmentId
            };

            _DbContext.OwnerApartments.Add(newOwnerApartment);
            _DbContext.SaveChanges();


            return Ok(newOwnerApartment);
        }




        [HttpPut] ///UPDATE

        public ActionResult Update(OwnerApartmentUpdateVM x)
        {
            var updatedOwnerApartment = _DbContext.OwnerApartments.Find(x.OwnerApartmentID);

            if (updatedOwnerApartment == null)
            {
                return BadRequest();
            }

            updatedOwnerApartment.OwnerApartmentID = x.OwnerApartmentID;
            updatedOwnerApartment.OwnerID = x.OwnerID;
            updatedOwnerApartment.ApartmentId = x.ApartmentId;

            _DbContext.OwnerApartments.Update(updatedOwnerApartment);
            _DbContext.SaveChanges();

            return Ok(updatedOwnerApartment);
        }
    }
}
