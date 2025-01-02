using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RS1_2024_25.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RuleController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;

        public RuleController(ApplicationDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }

        [HttpGet]
        public ActionResult<List<Rule>> Get()
        {
            var rules = _DbContext.Rules.ToList();

            if (rules == null)
            {
                return BadRequest();
            }

            return Ok(rules);
        }

        [HttpGet("{RuleID}")]
        public ActionResult<Rule> GetById(int RuleID)
        {
            var rule = _DbContext.Rules.Find(RuleID);

            if (rule == null)
            {
                return BadRequest();
            }

            return Ok(rule);
        }

        [HttpDelete("{RuleID}")]
        public ActionResult Delete(int RuleID)
        {
            var rule = _DbContext.Rules.Find(RuleID);

            if (rule == null)
            {
                return BadRequest();
            }

            _DbContext.Rules.Remove(rule);
            _DbContext.SaveChanges();

            return Ok();
        }

        [HttpPost] /// INSERT
        public ActionResult Insert(RuleInsertVM x)
        {
            var newRule = new Rule()
            {
                RuleText = x.RuleText,
            };

            _DbContext.Rules.Add(newRule);
            _DbContext.SaveChanges();

            return Ok(newRule);
        }

        [HttpPut] /// UPDATE
        public ActionResult Update(RuleUpdateVM x)
        {
            var updatedRule = _DbContext.Rules.Find(x.RuleID);

            if (updatedRule == null)
            {
                return BadRequest();
            }

            updatedRule.RuleID = x.RuleID;
            updatedRule.RuleText = x.RuleText;

            _DbContext.Rules.Update(updatedRule);
            _DbContext.SaveChanges();

            return Ok(updatedRule);
        }
    }
    }
