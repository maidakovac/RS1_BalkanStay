using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data
{
    public class OwnerApartment
    {
        public int OwnerApartmentID { get; set; }

        [ForeignKey(nameof(Account))]
        public int AccountID { get; set; } 
        public Account? Account { get; set; }

        [ForeignKey(nameof(Apartment))]
        public int ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }
    }
}
