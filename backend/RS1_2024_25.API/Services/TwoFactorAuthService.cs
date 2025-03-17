using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Helpers;

namespace RS1_2024_25.API.Services
{
    public class TwoFactorAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService; // Or SMS Service

        public TwoFactorAuthService(ApplicationDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task<string> Generate2FAToken(int accountId)
        {
            var token = GenerateRandomToken(); // 6-digit code
            var tokenHash = TokenHasher.HashToken(token); // Hash the token before storing

            var expiration = DateTime.UtcNow.AddMinutes(5); // 5-minute expiration

            var existing2FA = await _context.TwoFactorAuths
                .FirstOrDefaultAsync(tfa => tfa.AccountId == accountId);

            if (existing2FA != null)
            {
                _context.TwoFactorAuths.Remove(existing2FA); // Remove old token
            }

            var twoFactorAuth = new TwoFactorAuth
            {
                AccountId = accountId,
                AuthTokenHash = tokenHash, // Store the hashed token
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = expiration
            };

            _context.TwoFactorAuths.Add(twoFactorAuth);
            await _context.SaveChangesAsync();

            var account = await _context.Accounts.FindAsync(accountId);
            if (account != null)
            {
                //await _emailService.SendEmailAsync(account.Email, "Your 2FA Code", $"Your code is: {token}");
            }

            return token; // Send plain token to user, but store only hashed version
        }

        private string GenerateRandomToken()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString(); // Generates a 6-digit code
        }

        public async Task<bool> Verify2FAToken(int accountId, string token)
        {
            var twoFactorAuth = await _context.TwoFactorAuths
                .Where(tfa => tfa.AccountId == accountId)
                .OrderByDescending(tfa => tfa.CreatedAt)
                .FirstOrDefaultAsync();

            if (twoFactorAuth == null || twoFactorAuth.ExpiresAt < DateTime.UtcNow)
            {
                return false; // Invalid or expired token
            }

            // Verify hashed token
            if (!TokenHasher.VerifyToken(token, twoFactorAuth.AuthTokenHash))
            {
                return false; // Token doesn't match
            }

            // Delete used token
            _context.TwoFactorAuths.Remove(twoFactorAuth);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
