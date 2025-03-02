using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RS1_2024_25.API.Data
{
    public class OwnerReview
    {
        public int OwnerReviewID { get; set; }

        // FK za Owner (AccountID naslijeđen od Account)
        public int OwnerID { get; set; }

        [JsonIgnore]
        public Owner Owner { get; set; }

        // FK za User (AccountID naslijeđen od Account)
        public int UserID { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        public string Rating { get; set; }
    }
}