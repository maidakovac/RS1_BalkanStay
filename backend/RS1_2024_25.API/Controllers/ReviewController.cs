using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RS1_2024_25.API.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class ReviewController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;


        public ReviewController(ApplicationDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }



        [HttpGet]

        public ActionResult<List<Review>> Get()
        {
            var reviews = _DbContext.Reviews.ToList();

            if (reviews == null)
            {
                return BadRequest();
            }


            return Ok(reviews);
        }

        [HttpGet("{ReviewID}")]

        public ActionResult<Review> GetById(int ReviewID)
        {
            var reviews = _DbContext.Reviews.Find(ReviewID);

            if (reviews == null)
            {
                return BadRequest();
            }

            return Ok(reviews);
        }




        [HttpDelete("{ReviewID}")]

        public ActionResult Delete(int ReviewID)
        {
            var review = _DbContext.Reviews.Find(ReviewID);

            if (review == null)
            {
                return BadRequest();
            }

            _DbContext.Reviews.Remove(review);
            _DbContext.SaveChanges();

            return Ok();
        }




        [HttpPost] /// INSERT

        public ActionResult Insert(ReviewInsertVM x)
        {
            var newReview = new Review()
            {
                ApartmentId=x.ApartmentId,
                Rating=x.Rating,
                Comment=x.Comment
            };

            _DbContext.Reviews.Add(newReview);
            _DbContext.SaveChanges();


            return Ok(newReview);
        }




        [HttpPut] ///UPDATE

        public ActionResult Update(ReviewUpdateVM x)
        {
            var updatedReview = _DbContext.Reviews.Find(x.ReviewID);

            if (updatedReview == null)
            {
                return BadRequest();
            }

            updatedReview.ApartmentId = x.ApartmentId;

            updatedReview.Rating = x.Rating;
            updatedReview.Comment = x.Comment;

            _DbContext.Reviews.Update(updatedReview);
            _DbContext.SaveChanges();

            return Ok(updatedReview);
        }
    }
}
