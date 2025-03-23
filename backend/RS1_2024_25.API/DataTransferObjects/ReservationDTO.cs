namespace RS1_2024_25.API.DataTransferObjects
{
    public class ReservationDTO
    {
        public int ReservationID { get; set; }
        public int AccountID { get; set; }
        public int ApartmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }

        // Account details
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
