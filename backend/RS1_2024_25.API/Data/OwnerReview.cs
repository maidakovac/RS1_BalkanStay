using RS1_2024_25.API.Data.Models.Auth;

namespace RS1_2024_25.API.Data
{
    public class OwnerReview
    {
        public int OwnerReviewID { get; set; }
        public int OwnerID { get; set; }
        public Owner Owner { get; set; }
        public int UserID { get; set; }
        public MyAppUser MyAppUser   { get; set; }
        public string Rating { get; set; }
    }
}
