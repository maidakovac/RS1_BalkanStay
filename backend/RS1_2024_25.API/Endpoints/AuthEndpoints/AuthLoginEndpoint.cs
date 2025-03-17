using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Services;
using System.Threading;
using System.Threading.Tasks;

namespace RS1_2024_25.API.Endpoints.Auth
{
    [Route("auth")]
    [ApiController]
    public class AuthLoginEndpoint : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly MyAuthService _authService;
        private readonly PasswordHasherService _passwordHasherService;
        private readonly TwoFactorAuthService _twoFactorAuthService;

        public AuthLoginEndpoint(ApplicationDbContext db, MyAuthService authService, PasswordHasherService passwordHasherService, TwoFactorAuthService twoFactorAuthService)
        {
            _db = db;
            _authService = authService;
            _passwordHasherService = passwordHasherService;
            _twoFactorAuthService = twoFactorAuthService; 
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> HandleAsync([FromBody] LoginRequest request, CancellationToken cancellationToken = default)
        {
            var loggedInUser = await _db.Accounts
                .Include(a => a.TwoFactorAuth)
                .FirstOrDefaultAsync(u => u.Username == request.Username || u.Email == request.Email, cancellationToken);

            if (loggedInUser == null)
            {
                return Unauthorized(new { Message = "Incorrect username or email" });
            }

            var passwordHasher = new PasswordHasher<Account>();
            var passwordVerificationResult = passwordHasher.VerifyHashedPassword(loggedInUser, loggedInUser.Password, request.Password);

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return Unauthorized(new { Message = "Incorrect password" });
            }


            if (loggedInUser.TwoFactorAuth != null) 
            {
                Console.WriteLine($"[DEBUG] Generating 2FA token for UserId: {loggedInUser.AccountID}");

                var token = await _twoFactorAuthService.Generate2FAToken(loggedInUser.AccountID);

                return Ok(new
                {
                    Requires2FA = true,
                    Message = "A verification code has been sent to your email.",
                    UserId = loggedInUser.AccountID
                });
            }


            var newAuthToken = await _authService.GenerateAuthToken(loggedInUser, cancellationToken);
            var authInfo = _authService.GetAuthInfo(newAuthToken);

            return Ok(new LoginResponse
            {
                Token = newAuthToken.Value,
                MyAuthInfo = authInfo
            });
        }

        public class LoginRequest
        {
            public string? Username { get; set; }
            public string? Email { get; set; }
            public required string Password { get; set; }
        }

        public class LoginResponse
        {
            public required MyAuthInfo? MyAuthInfo { get; set; }
            public string Token { get; internal set; }
        }
    }
}
