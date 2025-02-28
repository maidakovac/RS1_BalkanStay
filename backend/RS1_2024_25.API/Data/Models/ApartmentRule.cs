using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RS1_2024_25.API.Data
{
    public class ApartmentRule
    {
        public int ApartmentRuleID { get; set; }

        [ForeignKey(nameof(Apartment))]

        public int ApartmentId { get; set; }

        [JsonIgnore]
        public Apartment? Apartment { get; set; }

        [ForeignKey(nameof(Rule))]

        public int RuleID { get; set; }

        [JsonIgnore]
        public Rule? Rule { get; set; }

    }
}
