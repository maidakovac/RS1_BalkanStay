namespace RS1_2024_25.API.Data
{
    public class Owner
    {
        public int OwnerID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        public List<OwnerReview> OwnerReviews { get; set; }
        public List<OwnerApartment> OwnerApartments { get; set; }

    }
}
