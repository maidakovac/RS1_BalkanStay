using RS1_2024_25.API.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.ViewModel
{
    public class ApartmentImageUpdateVM
    {
        public int ApartmentImageID { get; set; }
        public int ApartmentId { get; set; }
        public int ImageID { get; set; }
    }
}
