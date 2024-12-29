namespace RS1_2024_25.API.Data
{
    public class ApartmentAmenity
    {
        public int ApartmentAmenityID { get; set; }
        public int ApartmentId { get; set; }
        public Apartment Apartment  { get; set; }
        public int AmenityID { get; set; }
        public Amenity Amenity { get; set; }
    }
}
