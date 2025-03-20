using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Helpers;

namespace RS1_2024_25.API.Services
{
    public class TwoFactorAuthService
    {
        private readonly ApplicationDbContext _context; 
        private readonly EmailService _emailService;


        public TwoFactorAuthService(ApplicationDbContext context, EmailService emailService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _emailService = emailService;
        }

        public async Task<string> Generate2FAToken(int accountId)
        {
            var user = await _context.Accounts
                .Include(a => a.TwoFactorAuth)
                .FirstOrDefaultAsync(a => a.AccountID == accountId);

            if (user == null)
            {
                throw new InvalidOperationException($"User with ID {accountId} not found.");
            }

            var token = GenerateRandomToken();
            var tokenHash = TokenHasher.HashToken(token);
            var expiration = DateTime.UtcNow.AddMinutes(5);

            if (user.TwoFactorAuth == null)
            {
                Console.WriteLine($"[ERROR] User does not have 2FA enabled.");
                return null;
            }

  
            user.TwoFactorAuth.AuthTokenHash = tokenHash;
            user.TwoFactorAuth.CreatedAt = DateTime.UtcNow;
            user.TwoFactorAuth.ExpiresAt = expiration;

            await _context.SaveChangesAsync();

            await _emailService.SendResetEmailAsync(user.Email, $"Your new 2FA Code: {token}");

            return token;
        }



        public async Task<bool> Verify2FAToken(int accountId, string token)
        {
            Console.WriteLine($"[DEBUG] Verifying 2FA for UserId: {accountId} with Token: {token}");

            var twoFactorAuth = await _context.TwoFactorAuths
                .Where(tfa => tfa.AccountId == accountId)
                .OrderByDescending(tfa => tfa.CreatedAt)
                .FirstOrDefaultAsync();

            if (twoFactorAuth == null)
            {
                Console.WriteLine($"[ERROR] No 2FA record found for UserId: {accountId}");
                return false;
            }

            Console.WriteLine($"[DEBUG] Stored Hash: {twoFactorAuth.AuthTokenHash}");
            Console.WriteLine($"[DEBUG] User Input Token: {token}");

            if (!TokenHasher.VerifyToken(token, twoFactorAuth.AuthTokenHash))
            {
                Console.WriteLine($"[ERROR] 2FA token mismatch for UserId: {accountId}");
                return false;
            }

            Console.WriteLine($"[SUCCESS] 2FA verified successfully for UserId: {accountId}");

            _context.TwoFactorAuths.Remove(twoFactorAuth);
            await _context.SaveChangesAsync();

            return true;
        }


        private string GenerateRandomToken()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
}
