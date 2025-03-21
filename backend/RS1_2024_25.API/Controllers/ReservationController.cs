using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.ViewModel;
using System.Net.NetworkInformation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RS1_2024_25.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReservationController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;


        public ReservationController(ApplicationDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }



        [HttpGet]

        public ActionResult<List<Reservation>> Get()
        {
            var reservations = _DbContext.Reservations
                                            .Include(x => x.Apartment)
                                            .ToList();

            if (reservations == null)
            {
                return BadRequest();
            }


            return Ok(reservations);
        }

        [HttpGet("{ReservationID}")]

        public ActionResult<Reservation> GetById(int ReservationID)
        {
            var reservations = _DbContext.Reservations
                                .Include(x => x.Apartment)
                                .FirstOrDefault(a => ReservationID == ReservationID);
                                    
            if (reservations == null)
            {
                return BadRequest();
            }

            return Ok(reservations);
        }




        [HttpDelete("{ReservationID}")]

        public ActionResult Delete(int ReservationID)
        {
            var reservation = _DbContext.Reservations.Find(ReservationID);

            if (reservation == null)
            {
                return BadRequest();
            }

            _DbContext.Reservations.Remove(reservation);
            _DbContext.SaveChanges();

            return Ok();
        }




        [HttpPost] /// INSERT

        public ActionResult Insert(ReservationInsertVM x)
        {
            bool isOverlapping = _DbContext.Reservations.Any(r =>
        r.ApartmentId == x.ApartmentId &&
        r.Status && // Samo aktivne rezervacije
        !(r.EndDate < x.StartDate || r.StartDate > x.EndDate) // Provera preklapanja
    );

            if (isOverlapping)
            {
                return BadRequest("Unavailable for these dates!");
            }

            var newReservation = new Reservation()
            {
                AccountID = x.AccountID,
                ApartmentId = x.ApartmentId,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Status = x.Status
            };

            _DbContext.Reservations.Add(newReservation);
            _DbContext.SaveChanges();

            return Ok(newReservation);
        }




        [HttpPut] ///UPDATE

        public ActionResult Update(ReservationUpdateVM x)
        {
            var updatedReservation = _DbContext.Reservations.Find(x.ReservationID);

            if (updatedReservation == null)
            {
                return BadRequest();
            }

            updatedReservation.AccountID = x.AccountID;
            updatedReservation.ApartmentId = x.ApartmentId;
            updatedReservation.StartDate = x.StartDate;
            updatedReservation.EndDate = x.EndDate;
            updatedReservation.Status = x.Status;

            _DbContext.Reservations.Update(updatedReservation);
            _DbContext.SaveChanges();

            return Ok(updatedReservation);
        }


        [HttpGet("GetOccupiedDates/{apartmentId}")]
        public IActionResult GetOccupiedDates(int apartmentId)
        {
            var occupiedDates = _DbContext.Reservations
                .Where(r => r.ApartmentId == apartmentId && r.Status)
                .Select(r => new { r.StartDate, r.EndDate })
                .ToList();

            return Ok(occupiedDates);
        }

    }
}
