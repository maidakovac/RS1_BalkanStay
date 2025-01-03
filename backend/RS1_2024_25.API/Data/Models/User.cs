using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models.Auth
{
    public class User : Account
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

        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<OwnerReview> OwnerReviews { get; set; }

    }
}
