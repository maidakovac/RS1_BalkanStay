namespace RS1_2024_25.API.Data
{
    public class ApartmentRule
    {
        public int ApartmentRuleID { get; set; }
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        public int RuleID { get; set; }
        public Rule Rule { get; set; }

    }
}
