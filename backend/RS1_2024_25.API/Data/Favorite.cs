using RS1_2024_25.API.Data.Models.Auth;

namespace RS1_2024_25.API.Data
{
    public class Favorite
    {
        public int FavoriteID { get; set; }
        public int UserID { get; set; }
        public MyAppUser MyAppUser   { get; set; }
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
    }
}
