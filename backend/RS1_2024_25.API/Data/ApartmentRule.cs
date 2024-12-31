using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data
{
    public class ApartmentRule
    {
        public int ApartmentRuleID { get; set; }

        [ForeignKey(nameof(Apartment))]
        public int ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }

        [ForeignKey(nameof(Rule))]
        public int RuleID { get; set; }
        public Rule? Rule { get; set; }

    }
}
