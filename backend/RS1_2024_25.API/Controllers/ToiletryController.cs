using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RS1_2024_25.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ToiletryController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;

        public ToiletryController(ApplicationDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }

        [HttpGet]
        public ActionResult<List<Toiletry>> Get()
        {
            var toiletries = _DbContext.Toiletries.ToList();

            if (toiletries == null)
            {
                return BadRequest();
            }

            return Ok(toiletries);
        }

        [HttpGet("{ToiletryId}")]
        public ActionResult<Toiletry> GetById(int ToiletryId)
        {
            var toiletry = _DbContext.Toiletries.Find(ToiletryId);

            if (toiletry == null)
            {
                return BadRequest();
            }

            return Ok(toiletry);
        }

        [HttpDelete("{ToiletryId}")]
        public ActionResult Delete(int ToiletryId)
        {
            var toiletry = _DbContext.Toiletries.Find(ToiletryId);

            if (toiletry == null)
            {
                return BadRequest();
            }

            _DbContext.Toiletries.Remove(toiletry);
            _DbContext.SaveChanges();

            return Ok();
        }

        [HttpPost] /// INSERT
        public ActionResult Insert(ToiletryInsertVM toiletry)
        {
            var newToiletry = new Toiletry()
            {
                Name = toiletry.Name
            };

            _DbContext.Toiletries.Add(newToiletry);
            _DbContext.SaveChanges();

            return Ok(newToiletry);
        }

        [HttpPut] ///UPDATE
        public ActionResult Update(ToiletryUpdateVM toiletry)
        {
            var updatedToiletry = _DbContext.Toiletries.Find(toiletry.ToiletryID);

            if (updatedToiletry == null)
            {
                return BadRequest();
            }

            updatedToiletry.ToiletryID = toiletry.ToiletryID;
            updatedToiletry.Name = toiletry.Name;

            _DbContext.Toiletries.Update(updatedToiletry);
            _DbContext.SaveChanges();

            return Ok();
        }

    }
}
