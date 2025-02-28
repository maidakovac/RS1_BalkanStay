using System.Text.Json.Serialization;

namespace RS1_2024_25.API.Data
{
    public class Rule
    {
        public int RuleID { get; set; }
        public string? RuleText { get; set; }


        [JsonIgnore]
        public List<ApartmentRule>? ApartmentRules { get; set; }

    }
}
