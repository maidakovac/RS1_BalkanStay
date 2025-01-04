using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.ViewModel;

namespace RS1_2024_25.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AdministratorController : Controller
    {
        private readonly ApplicationDbContext _DbContext;

        public AdministratorController(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        // GET: /Administrator/Get
        [HttpGet]
        public ActionResult<List<Administrator>> Get()
        {
            var administrators = _DbContext.Administrators.ToList();

            if (administrators == null || administrators.Count == 0)
                return BadRequest();

            return Ok(administrators);
        }

        // GET: /Administrator/GetById/{AccountID}
        [HttpGet("{AccountID}")]
        public ActionResult<Administrator> GetById(int AccountID)
        {
            var administrator = _DbContext.Administrators.Find(AccountID);

            if (administrator == null)
                return BadRequest();

            return Ok(administrator);
        }

        // DELETE: /Administrator/Delete/{AccountID}
        [HttpDelete("{AccountID}")]
        public ActionResult Delete(int AccountID)
        {
            var administrator = _DbContext.Administrators.Find(AccountID);

            if (administrator == null)
                return BadRequest();

            _DbContext.Administrators.Remove(administrator);
            _DbContext.SaveChanges();

            return Ok();
        }

        // POST: /Administrator/Insert
        [HttpPost]
        public ActionResult Insert(AdministratorInsertViewModel adminVM)
        {
            var newAdministrator = new Administrator
            {
                Username = adminVM.Username,
                Email = adminVM.Email,
                Password = adminVM.Password,
                FirstName = adminVM.FirstName,
                LastName = adminVM.LastName,
                Image = adminVM.Image
            };

            _DbContext.Administrators.Add(newAdministrator);
            _DbContext.SaveChanges();

            return Ok(newAdministrator);
        }

        // PUT: /Administrator/Update
        [HttpPut]
        public ActionResult Update(AdministratorUpdateViewModel adminVM)
        {
            var administrator = _DbContext.Administrators.Find(adminVM.AccountID);

            if (administrator == null)
                return BadRequest();

            administrator.Username = adminVM.Username;
            administrator.Email = adminVM.Email;
            administrator.FirstName = adminVM.FirstName;
            administrator.LastName = adminVM.LastName;
            administrator.Image = adminVM.Image;

            _DbContext.Administrators.Update(administrator);
            _DbContext.SaveChanges();

            return Ok(administrator);
        }
    }
}
