namespace RS1_2024_25.API.ViewModels
{
    public class ApartmentImageDTO
    {
        public int ApartmentImageID { get; set; }
        public int ApartmentId { get; set; }
        public int ImageID { get; set; }
        public string ImageUrl { get; set; } // ✅ Use URL instead of Base64
    }
}
