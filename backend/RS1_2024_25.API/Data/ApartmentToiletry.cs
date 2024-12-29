namespace RS1_2024_25.API.Data
{
    public class ApartmentToiletry
    {
        public int ApartmentToiletryID { get; set; }
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        public int ToiletryID { get; set; }
        public Toiletry Toiletry { get; set; }
    }
}
