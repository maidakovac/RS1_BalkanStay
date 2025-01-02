using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.ViewModel
{
    public class ReservationUpdateVM
    {
        public int ReservationID { get; set; }
        public int AccountID { get; set; }
        public int ApartmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
    }
}
