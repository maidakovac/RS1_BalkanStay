using System.Text.Json.Serialization;

namespace RS1_2024_25.API.Data.Models.Auth
{
    public class Account
    {
        public int AccountID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public TwoFactorAuth TwoFactorAuth { get; set; }

        [JsonIgnore]
        public User? User => this as User;

        public bool isUser => User != null;


        [JsonIgnore]
        public Administrator? Administrator => this as Administrator;

        public bool isAdministrator => Administrator != null;


        [JsonIgnore]
        public Owner? Owner => this as Owner;

        public bool isOwner => Owner != null;
    }
}

