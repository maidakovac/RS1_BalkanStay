using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;

namespace RS1_2024_25.API.Data
{
    public class Owner:Account
    {

        public string Email { get; set; }
        public string Phone { get; set; }
        public int GenderID { get; set; }
        public Gender Gender { get; set; }


        public int CityID { get; set; }
        public City City { get; set; }

        public byte[] Image { get; set; }

        public DateTime CreatedAt { get; set; }


        public List<OwnerReview> OwnerReviews { get; set; }
        public List<OwnerApartment> OwnerApartments { get; set; }

    }
}
