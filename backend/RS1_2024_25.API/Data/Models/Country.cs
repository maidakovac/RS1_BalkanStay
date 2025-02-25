using RS1_2024_25.API.Helper;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RS1_2024_25.API.Data.Models;

public class Country : IMyBaseEntity
{
    public int ID { get; set; }
    public string Name { get; set; }

    [JsonIgnore]
    public List<City>? Cities { get; set; }

    public override string ToString()
    {
        return Name;
    }
}