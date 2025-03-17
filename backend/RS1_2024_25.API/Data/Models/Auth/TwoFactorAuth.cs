using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RS1_2024_25.API.Data.Models.Auth
{
    public class TwoFactorAuth
    {
        [Key]
        public int TwoFactorAuthId { get; set; }

        [Required]
        [ForeignKey("Account")]
        public int AccountId { get; set; }

        [Required]
        [MaxLength(128)] 
        public string AuthTokenHash { get; set; } 

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime ExpiresAt { get; set; }

        [JsonIgnore] 
        public virtual Account Account { get; set; }
    }
}
