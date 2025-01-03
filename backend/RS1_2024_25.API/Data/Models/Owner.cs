using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;

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


        public List<OwnerReview> OwnerReviews { get; set; }
        public List<OwnerApartment> OwnerApartments { get; set; }

    }
}
