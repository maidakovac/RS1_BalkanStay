using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data
{
    public class ApartmentAmenity
    {
        public int ApartmentAmenityID { get; set; }

        [ForeignKey(nameof(Apartment))]
        public int ApartmentId { get; set; }
        public Apartment? Apartment  { get; set; }

        [ForeignKey(nameof(Amenity))]

        public int AmenityID { get; set; }
        public Amenity? Amenity { get; set; }
    }
}
