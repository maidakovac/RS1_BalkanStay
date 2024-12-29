namespace RS1_2024_25.API.Data
{
    public class ApartmentImage
    {
        public int ApartmentImageID { get; set; }
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        public byte[] ImageID { get; set; }

    }
}
