using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RS1_2024_25.API.Data
{
    public class ApartmentAmenity
    {
        public int ApartmentAmenityID { get; set; }

        [ForeignKey(nameof(Apartment))]
        public int ApartmentId { get; set; }

        [JsonIgnore]
        public Apartment? Apartment  { get; set; }

        [ForeignKey(nameof(Amenity))]

        public int AmenityID { get; set; }

        [JsonIgnore]
        public Amenity? Amenity { get; set; }
    }
}
