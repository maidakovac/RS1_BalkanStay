namespace RS1_2024_25.API.Data
{
    public class Amenity
    {
        public int AmenityID { get; set; }
        public string AmenityText { get; set; }
        public List<ApartmentAmenity> ApartmentAmenities { get; set; }


    }
}
