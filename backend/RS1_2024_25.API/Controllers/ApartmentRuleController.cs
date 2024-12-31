using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.ViewModel;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RS1_2024_25.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ApartmentRuleController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;

        public ApartmentRuleController(ApplicationDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }

        [HttpGet]
        public ActionResult<List<ApartmentRule>> Get()
        {
            var apartmentRules = _DbContext.ApartmentRules.ToList();

            if (apartmentRules == null)
            {
                return BadRequest();
            }

            return Ok(apartmentRules);
        }

        [HttpGet("{ApartmentRuleID}")]
        public ActionResult<ApartmentRule> GetById(int ApartmentRuleID)
        {
            var apartmentRule = _DbContext.ApartmentRules.Find(ApartmentRuleID);

            if (apartmentRule == null)
            {
                return BadRequest();
            }

            return Ok(apartmentRule);
        }

        [HttpDelete("{ApartmentRuleID}")]
        public ActionResult Delete(int ApartmentRuleID)
        {
            var apartmentRule = _DbContext.ApartmentRules.Find(ApartmentRuleID);

            if (apartmentRule == null)
            {
                return BadRequest();
            }

            _DbContext.ApartmentRules.Remove(apartmentRule);
            _DbContext.SaveChanges();

            return Ok();
        }

        [HttpPost] /// INSERT
        public ActionResult Insert(ApartmentRuleInsertVM x)
        {
            var newApartmentRule = new ApartmentRule()
            {
                ApartmentId = x.ApartmentId,
                RuleID = x.RuleID
            };

            _DbContext.ApartmentRules.Add(newApartmentRule);
            _DbContext.SaveChanges();

            return Ok(newApartmentRule);
        }

        [HttpPut] /// UPDATE
        public ActionResult Update(ApartmentRuleUpdateVM x)
        {
            var updatedApartmentRule = _DbContext.ApartmentRules.Find(x.ApartmentRuleID);

            if (updatedApartmentRule == null)
            {
                return BadRequest();
            }

            updatedApartmentRule.ApartmentRuleID = x.ApartmentRuleID;
            updatedApartmentRule.ApartmentId = x.ApartmentId;
            updatedApartmentRule.RuleID = x.RuleID;

            _DbContext.ApartmentRules.Update(updatedApartmentRule);
            _DbContext.SaveChanges();

            return Ok(updatedApartmentRule);
        }

    }
}
