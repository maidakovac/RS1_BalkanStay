using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RS1_2024_25.API.Data
{
    public class ApartmentToiletry
    {
        public int ApartmentToiletryID { get; set; }

        [ForeignKey(nameof(Apartment))]
        public int ApartmentId { get; set; }

        [JsonIgnore]
        public Apartment? Apartment { get; set; }

        [ForeignKey(nameof(Toiletry))]
        public int ToiletryID { get; set; }

        [JsonIgnore]
        public Toiletry? Toiletry { get; set; }
    }
}
