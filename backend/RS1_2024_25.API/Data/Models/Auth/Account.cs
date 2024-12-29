namespace RS1_2024_25.API.Data.Models.Auth
{
    public class Account
    {
        public int AccountID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int MyAppUserID { get; set; } // Strani ključ
        public MyAppUser MyAppUser { get; set; }

        public TwoFactorAuth TwoFactorAuth { get; set; }
    }
}

