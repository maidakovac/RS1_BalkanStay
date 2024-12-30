using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RS1_2024_25.API.ViewModel
{
    public class CityUpdateVM
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public Country? Country { get; set; }

        public List<Apartment>? Apartments { get; set; } = new List<Apartment>();
    }
}

