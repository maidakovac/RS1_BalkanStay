using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Helper;
using RS1_2024_25.API.Helper.Api;
using RS1_2024_25.API.Services;
using System.Threading;
using System.Threading.Tasks;
using static RS1_2024_25.API.Endpoints.Auth.AuthLoginEndpoint;

namespace RS1_2024_25.API.Endpoints.Auth
{
    [Route("auth")]
    public class AuthLoginEndpoint(ApplicationDbContext db, MyAuthService authService) : MyEndpointBaseAsync
        .WithRequest<LoginRequest>
        .WithActionResult<LoginResponse>
    {
        [HttpPost("login")]
        public override async Task<ActionResult<LoginResponse>> HandleAsync(LoginRequest request, CancellationToken cancellationToken = default)
        {
            // Fetch the account using email
            var loggedInUser = await db.Accounts
                .FirstOrDefaultAsync(u => u.Email == request.Email && u.Password == request.Password, cancellationToken);

            // If no user is found, return Unauthorized
            if (loggedInUser == null)
            {
                return Unauthorized(new { Message = "Incorrect email or password" });
            }

            // Generate authentication token
            var newAuthToken = await authService.GenerateAuthToken(loggedInUser, cancellationToken);

            // Get authentication information
            var authInfo = authService.GetAuthInfo(newAuthToken);

            // Return response with token and authentication info
            return new LoginResponse
            {
                Token = newAuthToken.Value,
                MyAuthInfo = authInfo
            };
        }

        public class LoginRequest
        {
            public required string Email { get; set; }
            public required string Password { get; set; }
        }

        public class LoginResponse
        {
            public required MyAuthInfo? MyAuthInfo { get; set; }
            public string Token { get; internal set; }
        }
    }
}

