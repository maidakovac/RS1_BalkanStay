using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Services;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RS1_2024_25.API.Endpoints.Auth
{
    [Route("auth/password")]
    [ApiController]
    public class AuthPasswordEndpoint : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly EmailService _emailService; 
        private readonly string frontendResetUrl = "http://localhost:4200/auth/reset-password";

        public AuthPasswordEndpoint(ApplicationDbContext db, EmailService emailService)
        {
            _db = db;
            _emailService = emailService;
        }


        [HttpPost("forgot")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            if (string.IsNullOrEmpty(request.Email))
                return BadRequest(new { message = "Email is required." });

            var user = await _db.Accounts.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
                return NotFound(new { message = "Email not found." });

            string resetToken = Guid.NewGuid().ToString();

            user.ResetToken = resetToken;
            user.ResetTokenExpiry = DateTime.UtcNow.AddHours(1);
            await _db.SaveChangesAsync();

            string resetUrl = $"{frontendResetUrl}?token={resetToken}";
            bool emailSent = await _emailService.SendResetEmailAsync(user.Email, resetUrl);

            if (!emailSent)
                return StatusCode(500, new { message = "Error sending email. Please try again." });

            return Ok(new { message = "Password reset link has been sent to your email." });
        }

        [HttpPost("reset")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            if (string.IsNullOrEmpty(request.Token) || string.IsNullOrEmpty(request.NewPassword))
                return BadRequest(new { message = "Invalid request." });

            var user = await _db.Accounts.FirstOrDefaultAsync(u => u.ResetToken == request.Token && u.ResetTokenExpiry > DateTime.UtcNow);
            if (user == null)
                return BadRequest(new { message = "Invalid or expired reset token." });

            var passwordHasher = new PasswordHasher<Account>();
            user.Password = passwordHasher.HashPassword(user, request.NewPassword);

            user.ResetToken = null;
            user.ResetTokenExpiry = null;
            await _db.SaveChangesAsync();

            return Ok(new { message = "Password has been reset successfully." });
        }

        public class ForgotPasswordRequest
        {
            public string? Email { get; set; }
        }

        public class ResetPasswordRequest
        {
            public string? Token { get; set; }
            public string? NewPassword { get; set; }
        }
    }
}
