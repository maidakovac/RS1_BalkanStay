using RS1_2024_25.API.Data.Models;

namespace RS1_2024_25.API.ViewModel
{
    public class ApartmentInsertVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public int PricePerNight { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
