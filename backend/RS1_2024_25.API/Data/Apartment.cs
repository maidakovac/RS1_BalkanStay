using RS1_2024_25.API.Data.Models;

namespace RS1_2024_25.API.Data
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public int PricePerNight { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public List<Reservation> Reservations { get; set; }
        public List<OwnerApartment> OwnerApartments { get; set; }
        public List<ApartmentImage> ApartmentImages { get; set; }
        public List<ApartmentRule> ApartmentRules { get; set; }
        public List<ApartmentAmenity> ApartmentAmenities { get; set; }
        public List<ApartmentToiletry> ApartmentToiletries { get; set; }
    }
}
