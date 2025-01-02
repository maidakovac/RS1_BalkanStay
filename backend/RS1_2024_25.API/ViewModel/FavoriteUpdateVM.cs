using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Data;

namespace RS1_2024_25.API.ViewModel
{
    public class FavoriteUpdateVM
    {
        public int FavoriteID { get; set; }
        public int MyAppUserID { get; set; }
        public int ApartmentId { get; set; }
    }
}