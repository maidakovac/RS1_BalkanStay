namespace RS1_2024_25.API.Data
{
    public class Image
    {
        public int ImageID { get; set; }
        public byte[] Photo{ get; set; }

        public List<ApartmentImage> ApartmentImages { get; set; }

    }
}
