using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data
{
    public class Favorite
    {
        public int FavoriteID { get; set; }

        [ForeignKey(nameof(MyAppUser))]
        public int MyAppUserID { get; set; }
        public MyAppUser? MyAppUser { get; set; }

        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
    }
}
