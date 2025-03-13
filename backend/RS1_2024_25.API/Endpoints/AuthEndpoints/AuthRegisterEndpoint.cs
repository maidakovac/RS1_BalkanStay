using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Helper.Api;
using RS1_2024_25.API.Services;
using System.Threading;
using System.Threading.Tasks;
using static RS1_2024_25.API.Endpoints.Auth.AuthRegisterEndpoint;

namespace RS1_2024_25.API.Endpoints.Auth
{
    [Route("auth")]
    public class AuthRegisterEndpoint(ApplicationDbContext db, MyAuthService authService) : MyEndpointBaseAsync
        .WithRequest<RegisterRequest>
        .WithActionResult<RegisterResponse>
    {
        [HttpPost("register")]
        public override async Task<ActionResult<RegisterResponse>> HandleAsync(RegisterRequest request, CancellationToken cancellationToken = default)
        {
            // Check if email already exists
            var existingUser = await db.Accounts.AnyAsync(u => u.Email == request.Email, cancellationToken);
            if (existingUser)
            {
                return BadRequest(new { Message = "Email is already in use." });
            }

            // Create a new account
            var newUser = new Account
            {
                Username = request.UserName,
                Email = request.Email,
                Password = authService.HashPassword(request.Password), // Sada se hashira!
                FirstName = request.FirstName,
                LastName = request.LastName
            };


            db.Accounts.Add(newUser);
            await db.SaveChangesAsync(cancellationToken);

            // Generiši authentication token
            var newAuthToken = await authService.GenerateAuthToken(newUser, cancellationToken);
            var authInfo = authService.GetAuthInfo(newAuthToken);

            return new RegisterResponse
            {
                Token = newAuthToken.Value,
                MyAuthInfo = authInfo
            };
        }

        public class RegisterRequest
        {
            public required string Email { get; set; }
            public required string Password { get; set; } // Treba se hashovati
            public required string FirstName { get; set; }
            public required string LastName { get; set; }
            public required string UserName { get; set; }
        }

        public class RegisterResponse
        {
            public required MyAuthInfo? MyAuthInfo { get; set; }
            public string Token { get; internal set; }
        }
    }
}
