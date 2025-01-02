namespace RS1_2024_25.API.Data.Models.Auth
{
    public class User : Account
    {
        public string Phone { get; set; }

        public int GenderID { get; set; }
        public Gender Gender { get; set; }


        public int CityID { get; set; }
        public City City { get; set; }

        public byte[]? Image { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
