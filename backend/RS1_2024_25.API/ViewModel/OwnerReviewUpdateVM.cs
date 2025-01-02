using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.ViewModel
{
    public class OwnerReviewUpdateVM
    {
        public int OwnerReviewID { get; set; }
        public int AccountID { get; set; }
        public string Rating { get; set; }
    }
}
