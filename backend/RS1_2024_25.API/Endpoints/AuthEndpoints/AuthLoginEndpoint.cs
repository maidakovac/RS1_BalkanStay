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
    public class AuthLoginEndpoint(ApplicationDbContext db, MyAuthService authService, PasswordHasherService passwordHasherService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> HandleAsync([FromBody] LoginRequest request, CancellationToken cancellationToken = default)
        {
            // Fetch user by username or email
            var loggedInUser = await db.Accounts
                .FirstOrDefaultAsync(u => (u.Username == request.Username || u.Email == request.Email), cancellationToken);

            if (loggedInUser == null)
            {
                return Unauthorized(new { Message = "Incorrect username or email" });
            }

            // Verify the hashed password
            var passwordHasher = new PasswordHasher<Account>();
            var passwordVerificationResult = passwordHasher.VerifyHashedPassword(loggedInUser, loggedInUser.Password, request.Password);

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return Unauthorized(new { Message = "Incorrect password" });
            }

            // Generate authentication token
            var newAuthToken = await authService.GenerateAuthToken(loggedInUser, cancellationToken);
            var authInfo = authService.GetAuthInfo(newAuthToken);

            return new LoginResponse
            {
                Token = newAuthToken.Value,
                MyAuthInfo = authInfo
            };
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
