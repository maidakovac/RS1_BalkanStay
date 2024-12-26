using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Helper;

namespace RS1_2024_25.API.Services
{
    public class MyAuthService
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly MyTokenGenerator myTokenGenerator;

        public MyAuthService(ApplicationDbContext dbContext, IHttpContextAccessor contextAccessor, MyTokenGenerator tokenGenerator)
        {
            applicationDbContext = dbContext;
            httpContextAccessor = contextAccessor;
            myTokenGenerator = tokenGenerator;
        }

        // Generate a new token for the user
        public async Task<MyAuthenticationToken> GenerateAuthToken(MyAppUser user, CancellationToken cancellationToken = default)
        {
            string randomToken = myTokenGenerator.Generate(10);

            var authToken = new MyAuthenticationToken
            {
                IpAddress = httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty,
                Value = randomToken,
                MyAppUser = user,
                RecordedAt = DateTime.Now
            };

            applicationDbContext.MyAuthenticationTokens.Add(authToken);
            await applicationDbContext.SaveChangesAsync(cancellationToken);

            return authToken;
        }

        // Revoke an authentication token
        public async Task<bool> RevokeAuthToken(string tokenValue, CancellationToken cancellationToken = default)
        {
            var authToken = await applicationDbContext.MyAuthenticationTokens
                .FirstOrDefaultAsync(t => t.Value == tokenValue, cancellationToken);

            if (authToken == null)
                return false;

            applicationDbContext.MyAuthenticationTokens.Remove(authToken);
            await applicationDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }

        // Get authentication info
        public MyAuthInfo GetAuthInfo()
        {
            string? authToken = httpContextAccessor.HttpContext?.Request.Headers["my-auth-token"];
            if (string.IsNullOrEmpty(authToken))
            {
                return GetAuthInfo(null);
            }

            var myAuthToken = applicationDbContext.MyAuthenticationTokens
                .Include(x => x.MyAppUser)
                .SingleOrDefault(x => x.Value == authToken);

            return GetAuthInfo(myAuthToken);
        }

        public MyAuthInfo GetAuthInfo(MyAuthenticationToken? myAuthToken)
        {
            if (myAuthToken == null)
            {
                return new MyAuthInfo
                {
                    IsLoggedIn = false
                };
            }

            var user = myAuthToken.MyAppUser;

            return new MyAuthInfo
            {
                UserId = user.UserID,
                Username = user.Email, // Use Email as Username
                FirstName = user.Email.Split('@')[0], // Derive FirstName from Email if necessary
                LastName = "N/A", // Placeholder as LastName no longer exists
                IsAdmin = false, // Placeholder for admin logic
                IsManager = false, // Placeholder for manager logic
                IsLoggedIn = true,
                SlikaPath = user.Image // Use the Image property for SlikaPath
            };
        }
    }

    // DTO to hold authentication information
    public class MyAuthInfo
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; } // Derived from Email
        public string LastName { get; set; } // Placeholder
        public bool IsAdmin { get; set; } // Defaulted to false
        public bool IsManager { get; set; } // Defaulted to false
        public bool IsLoggedIn { get; set; }
        public string SlikaPath { get; set; } // Maps to Image
    }
}
