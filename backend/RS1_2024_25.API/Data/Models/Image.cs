namespace RS1_2024_25.API.Data
{
//    public class Image
//    {
//        public int ImageID { get; set; }
//        public byte[] Photo { get; set; }

//        public List<ApartmentImage> ApartmentImages { get; set; }

//    }

    public class Image
    {
        public int ImageID { get; set; }
        public string ?ImagePath { get; set; } // ✅ Store the image file path instead of Base64

        public List<ApartmentImage> ApartmentImages { get; set; }
    }


}
