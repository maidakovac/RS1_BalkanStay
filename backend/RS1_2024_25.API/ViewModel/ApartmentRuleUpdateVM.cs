using RS1_2024_25.API.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.ViewModel
{
    public class ApartmentRuleUpdateVM
    {
        public int ApartmentRuleID { get; set; }
        public int ApartmentId { get; set; }

        public int RuleID { get; set; }
    }
}
