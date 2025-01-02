using RS1_2024_25.API.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data
{
    public class OwnerApartment
    {
        public int OwnerApartmentID { get; set; }

        [ForeignKey(nameof(Owner))]
        public int OwnerID { get; set; } 
        public Owner? Owner { get; set; }

        [ForeignKey(nameof(Apartment))]
        public int ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }
    }
}
