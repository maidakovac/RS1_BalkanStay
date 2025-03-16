using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RS1_2024_25.API.Endpoints.Auth
{
    [Route("auth/password")]
    [ApiController]
    public class AuthPasswordEndpoint(ApplicationDbContext db) : ControllerBase
    {
        private readonly string smtpServer = "smtp.gmail.com";
        private readonly int smtpPort = 587;
        private readonly string smtpUsername = "izellapin@gmail.com";
        private readonly string smtpPassword = "vsho odio tbie lgcz";
        private readonly string senderEmail = "izellapin@gmail.com";
        private readonly string frontendResetUrl = "http://localhost:4200/auth/reset-password";

        [HttpPost("forgot")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            if (string.IsNullOrEmpty(request.Email))
                return BadRequest(new { message = "Email is required." });

            var user = await db.Accounts.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
                return NotFound(new { message = "Email not found." });

            string resetToken = Guid.NewGuid().ToString();

            user.ResetToken = resetToken;
            user.ResetTokenExpiry = DateTime.UtcNow.AddHours(1);
            await db.SaveChangesAsync();

            bool emailSent = SendResetEmail(user.Email, resetToken);

            if (!emailSent)
                return StatusCode(500, new { message = "Error sending email. Please try again." });

            return Ok(new { message = "Password reset link has been sent to your email." });
        }

        [HttpPost("reset")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            if (string.IsNullOrEmpty(request.Token) || string.IsNullOrEmpty(request.NewPassword))
                return BadRequest(new { message = "Invalid request." });

            var user = await db.Accounts.FirstOrDefaultAsync(u => u.ResetToken == request.Token && u.ResetTokenExpiry > DateTime.UtcNow);
            if (user == null)
                return BadRequest(new { message = "Invalid or expired reset token." });

            var passwordHasher = new PasswordHasher<Account>();
            user.Password = passwordHasher.HashPassword(user, request.NewPassword);

            user.ResetToken = null;
            user.ResetTokenExpiry = null;
            await db.SaveChangesAsync();

            return Ok(new { message = "Password has been reset successfully." });
        }

        private bool SendResetEmail(string email, string resetToken)
        {
            try
            {
                string resetUrl = $"{frontendResetUrl}?token={resetToken}"; 

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(email);
                mail.Subject = "Password Reset Request";
                mail.Body = $"<p>Click the link below to reset your password:</p><p><a href='{resetUrl}'>{resetUrl}</a></p>";
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient(smtpServer, smtpPort)
                {
                    Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                    EnableSsl = true
                };

                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email sending failed: {ex.Message}");
                return false;
            }
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
