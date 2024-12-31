using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RS1_2024_25.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OwnerReviewController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;


        public OwnerReviewController(ApplicationDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }



        [HttpGet]

        public ActionResult<List<OwnerReview>> Get()
        {
            var ownerReviews = _DbContext.OwnerReviews.ToList();

            if (ownerReviews== null)
            {
                return BadRequest();
            }


            return Ok(ownerReviews);
        }

        [HttpGet("{OwnerReviewID}")]

        public ActionResult<OwnerReview> GetById(int OwnerReviewID)
        {
            var ownerReviews = _DbContext.OwnerReviews.Find(OwnerReviewID);

            if (ownerReviews == null)
            {
                return BadRequest();
            }

            return Ok(ownerReviews);
        }




        [HttpDelete("{OwnerReviewID}")]

        public ActionResult Delete(int OwnerReviewID)
        {
            var ownerReview = _DbContext.OwnerReviews.Find(OwnerReviewID);

            if (ownerReview == null)
            {
                return BadRequest();
            }

            _DbContext.OwnerReviews.Remove(ownerReview);
            _DbContext.SaveChanges();

            return Ok();
        }




        [HttpPost] /// INSERT

        public ActionResult Insert(OwnerReviewInsertVM x)
        {
            var newOwnerReview = new OwnerReview()
            {
                OwnerID = x.OwnerID,
                MyAppUserID = x.MyAppUserID,
                Rating = x.Rating
            };

            _DbContext.OwnerReviews.Add(newOwnerReview);
            _DbContext.SaveChanges();


            return Ok(newOwnerReview);
        }




        [HttpPut] ///UPDATE

        public ActionResult Update(OwnerReviewUpdateVM x)
        {
            var updatedOwnerReview = _DbContext.OwnerReviews.Find(x.OwnerReviewID);

            if (updatedOwnerReview == null)
            {
                return BadRequest();
            }
            updatedOwnerReview.OwnerReviewID = x.OwnerReviewID;
            updatedOwnerReview.OwnerID = x.OwnerID;
            updatedOwnerReview.MyAppUserID = x.MyAppUserID;
            updatedOwnerReview.Rating = x.Rating;

            _DbContext.OwnerReviews.Update(updatedOwnerReview);
            _DbContext.SaveChanges();

            return Ok(updatedOwnerReview);
        }
    }
}
