using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RS1_2024_25.API.Data
{
    public class Owner:Account
    {

        public string Phone { get; set; }

        public int CityID { get; set; }

        [ForeignKey(nameof(CityID))]
        public City City { get; set; }


        public int GenderID { get; set; }

        [ForeignKey(nameof(GenderID))]
        public Gender Gender { get; set; }


        public byte[]? Image { get; set; }

        public DateTime CreatedAt { get; set; }



        [JsonIgnore]
        public List<OwnerReview> OwnerReviews { get; set; }


        [JsonIgnore]
        public List<Apartment> Apartments { get; set; }

    }
}
