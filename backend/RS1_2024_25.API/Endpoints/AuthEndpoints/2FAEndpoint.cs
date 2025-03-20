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
        public async Task<ActionResult<TwoFactorResponse>> VerifyTwoFactorAsync([FromBody] TwoFactorRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _db.Accounts.FindAsync(request.UserId);
            if (user == null)
            {
                Console.WriteLine("❌ [ERROR] User not found.");
                return Unauthorized(new TwoFactorResponse { Message = "User not found." });
            }

            var isValid = await _twoFactorAuthService.Verify2FAToken(user.AccountID, request.Token);
            if (!isValid)
            {
                Console.WriteLine("❌ [ERROR] Invalid or expired 2FA token.");
                return Unauthorized(new TwoFactorResponse { Message = "Invalid or expired 2FA code." });
            }


            var newAuthToken = await _authService.GenerateAuthToken(user, cancellationToken);


            var authInfo = _authService.GetAuthInfo(newAuthToken);
            if (authInfo == null || !authInfo.IsLoggedIn)
            {
                Console.WriteLine("❌ [ERROR] MyAuthInfo is null or user is not logged in.");
            }
            else
            {
                Console.WriteLine($"✅ [SUCCESS] MyAuthInfo Retrieved: {authInfo.Username}");
            }

            return Ok(new TwoFactorResponse
            {
                Message = "2FA verified successfully.",
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

        public class TwoFactorResponse
        {
            public string Message { get; set; }
            public string Token { get; set; }
            public MyAuthInfo MyAuthInfo { get; set; }
        }



        [HttpPost("reset-2fa")]
        public async Task<IActionResult> ResetTwoFactorAuth([FromBody] TwoFactorRequest request)
        {
            Console.WriteLine($"🔄 [DEBUG] Received Reset 2FA Request: {request.UserId}");

            if (request == null)
            {
                Console.WriteLine("❌ [ERROR] Received null request body.");
                return BadRequest(new { Message = "Invalid request format. Request body is missing." });
            }

            if (request.UserId <= 0)
            {
                Console.WriteLine("❌ [ERROR] Invalid user ID received: " + request.UserId);
                return BadRequest(new { Message = "Invalid user ID." });
            }

            var user = await _db.Accounts
                .Include(a => a.TwoFactorAuth)
                .FirstOrDefaultAsync(a => a.AccountID == request.UserId);

            if (user == null)
            {
                Console.WriteLine("❌ [ERROR] User not found in database.");
                return NotFound(new { Message = "User not found." });
            }

            if (user.TwoFactorAuth == null)
            {
                Console.WriteLine("⚠️ [WARNING] User does not have 2FA enabled.");
                return BadRequest(new { Message = "2FA is not enabled for this user." });
            }

            Console.WriteLine("✅ [SUCCESS] Resetting 2FA for user " + request.UserId);

            user.TwoFactorAuth.AuthTokenHash = "";
            user.TwoFactorAuth.CreatedAt = DateTime.UtcNow;
            user.TwoFactorAuth.ExpiresAt = DateTime.UtcNow.AddMinutes(5);

            await _db.SaveChangesAsync();

            var newToken = await _twoFactorAuthService.Generate2FAToken(user.AccountID);

            Console.WriteLine($"✅ [SUCCESS] New 2FA Code Sent: {newToken}");

            return Ok(new { Message = "2FA reset successful. A new code has been sent.", Token = newToken });
        }



    }
}
