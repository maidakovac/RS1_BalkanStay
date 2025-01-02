using RS1_2024_25.API.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.ViewModel
{
    public class ApartmentToiletryUpdateVM
    {
        public int ApartmentToiletryID { get; set; }

        public int ApartmentId { get; set; }
        public int ToiletryID { get; set; }
    }
}
