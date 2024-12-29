using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RS1_2024_25.API.Data.Models.Auth
{
    public class TwoFactorAuth

    {
        [Key]
        public int TwoFactorAuthId { get; set; } // 2FAID
        public int AccountId { get; set; }       // Foreign Key to Account
        public string AuthToken { get; set; }    // Authentication Token
        public DateTime CreatedAt { get; set; }  // Timestamp when the token is created
        public DateTime ExpiresAt { get; set; }  // Timestamp when the token expires

        // Navigation Property
        public Account Account { get; set; }
    }
}
