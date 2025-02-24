using RS1_2024_25.API.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RS1_2024_25.API.Data.Models;

public class City: IMyBaseEntity
{
    [Key]
    public int ID { get; set; }
    public string Name { get; set; }


    [ForeignKey(nameof(Country))]
    public int CountryId { get; set; }
    public Country Country { get; set; }

    [JsonIgnore]
    public List<Apartment>? Apartments { get; set; } = new List<Apartment>();

    public override string ToString()
    {
        return Name;
    }
}