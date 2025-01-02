namespace RS1_2024_25.API.Data
{
    public class Rule
    {
        public int RuleID { get; set; }
        public string? RuleText { get; set; }
        public List<ApartmentRule>? ApartmentRules { get; set; }

    }
}
