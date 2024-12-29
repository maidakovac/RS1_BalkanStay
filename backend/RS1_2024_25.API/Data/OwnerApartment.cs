namespace RS1_2024_25.API.Data
{
    public class OwnerApartment
    {
        public int OwnerApartmentID { get; set; }
        public int OwnerID { get; set; }
        public Owner Owner { get; set; }
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
    }
}
