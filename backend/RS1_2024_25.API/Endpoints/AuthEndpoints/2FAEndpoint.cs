using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Services;
using RS1_2024_25.API.Data;
using static RS1_2024_25.API.Endpoints.Auth.AuthLoginEndpoint;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data.Models.Auth;

namespace RS1_2024_25.API.Endpoints.AuthEndpoints
{
    [Route("auth")]
    [ApiController]
    public class TwoFactorAuthEndpoint : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly TwoFactorAuthService _twoFactorAuthService;
        private readonly MyAuthService _authService;

        public TwoFactorAuthEndpoint(ApplicationDbContext db, TwoFactorAuthService twoFactorAuthService, MyAuthService authService)
        {
            _db = db;
            _twoFactorAuthService = twoFactorAuthService;
            _authService = authService;
        }

        [HttpPost("verify-2fa")]
        public async Task<ActionResult<LoginResponse>> VerifyTwoFactorAsync([FromBody] TwoFactorRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _db.Accounts.FindAsync(request.UserId);
            if (user == null)
            {
                return Unauthorized(new { Message = "User not found" });
            }

            var isValid = await _twoFactorAuthService.Verify2FAToken(user.AccountID, request.Token);
            if (!isValid)
            {
                return Unauthorized(new { Message = "Invalid or expired 2FA code" });
            }


            var newAuthToken = await _authService.GenerateAuthToken(user, cancellationToken);
            var authInfo = _authService.GetAuthInfo(newAuthToken);

            return Ok(new LoginResponse
            {
                Token = newAuthToken.Value,
                MyAuthInfo = authInfo
            });
        }


        [HttpPost("enable-2fa")]
        public async Task<IActionResult> EnableTwoFactorAuth([FromBody] TwoFactorEnableRequest request)
        {
            var user = await _db.Accounts.FindAsync(request.UserId);
            if (user == null)
            {
                return NotFound(new { Message = "User not found" });
            }

            if (user.TwoFactorAuth != null)
            {
                return BadRequest(new { Message = "2FA is already enabled for this user." });
            }

            var twoFactorAuth = new TwoFactorAuth
            {
                AccountId = user.AccountID,
                AuthTokenHash = "", 
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddMinutes(5)
            };

            user.TwoFactorAuth = twoFactorAuth;

            _db.TwoFactorAuths.Add(twoFactorAuth);
            await _db.SaveChangesAsync();

            return Ok(new { Message = "2FA enabled successfully." });
        }

        public class TwoFactorEnableRequest
        {
            public int UserId { get; set; }
        }



        public class TwoFactorRequest
        {
            public int UserId { get; set; }
            public required string Token { get; set; }
        }
    }
}
