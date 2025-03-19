namespace RS1_2024_25.API.DataTransferObjects
{
    public class ApartmentDTO
    {
        public int ApartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public int PricePerNight { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public List<string> Amenities { get; set; }
        public List<string> Toiletries { get; set; }
        public List<string> Rules { get; set; }
        public List<string> ImagePaths { get; set; }
    }
}
