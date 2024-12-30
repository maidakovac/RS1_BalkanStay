using RS1_2024_25.API.Data.Models;

namespace RS1_2024_25.API.ViewModel
{
    public class ApartmentUpdateVM
    {
        public int ApartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int PricePerNight { get; set; }
        public int CityId { get; set; }
    }
}
