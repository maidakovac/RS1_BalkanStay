using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data
{
    public class OwnerReview
    {
        public int OwnerReviewID { get; set; }

        [ForeignKey(nameof(Owner))]
        public int OwnerID { get; set; }
        public Owner? Owner { get; set; }

        [ForeignKey(nameof(MyAppUser))]
        public int MyAppUserID { get; set; }
        public MyAppUser? MyAppUser   { get; set; }

        public string Rating { get; set; }
    }
}
