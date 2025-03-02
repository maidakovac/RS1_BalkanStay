using System.Text.Json.Serialization;

namespace RS1_2024_25.API.Data
{
    public class Toiletry
    {
        public int ToiletryID { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<ApartmentToiletry> ApartmentToiletries { get; set; }

    }
}
