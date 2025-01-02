using RS1_2024_25.API.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.ViewModel
{
    public class OwnerApartmentUpdateVM
    {
        public int OwnerApartmentID { get; set; }
        public int AccountID { get; set; }
        public int ApartmentId { get; set; }
    }
}
