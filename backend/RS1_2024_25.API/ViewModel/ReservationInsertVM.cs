namespace RS1_2024_25.API.ViewModel
{
    public class ReservationInsertVM
    {
        public int AccountID { get; set; }
        public int ApartmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
    }
}
