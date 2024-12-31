using RS1_2024_25.API.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.ViewModel
{
    public class ApartmentAmenityUpdateVM
    {
        public int ApartmentAmenityID { get; set; }
        public int ApartmentId { get; set; }
        public int AmenityID { get; set; }
    }
}
