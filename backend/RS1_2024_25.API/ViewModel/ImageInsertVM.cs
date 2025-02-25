using RS1_2024_25.API.Data;

namespace RS1_2024_25.API.ViewModel
{
    public class ImageInsertVM
    {
        public string ImagePath { get; set; } // ✅ Store the image file path instead of Base64

        public List<ApartmentImage> ApartmentImages { get; set; }
    }
}
