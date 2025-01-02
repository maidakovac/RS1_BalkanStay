namespace RS1_2024_25.API.ViewModel
{
    public class ReviewUpdateVM
    {
        public int ReviewID { get; set; }
        public int ApartmentId { get; set; }

        public int AccountID { get; set; }

        public string Rating { get; set; }
        public string Comment { get; set; }
    }
}
