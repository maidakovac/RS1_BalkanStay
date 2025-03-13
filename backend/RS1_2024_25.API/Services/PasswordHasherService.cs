using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2024_25.API.Services
{
    public class PasswordHasherService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly PasswordHasher<Account> _passwordHasher;

        public PasswordHasherService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _passwordHasher = new PasswordHasher<Account>();
        }

        public void HashPasswordsForAllUsers()
        {
            var users = _dbContext.Accounts.ToList();

            foreach (var user in users)
            {
                // Skip if the password is already hashed
                if (!IsPasswordHashed(user.Password))
                {
                    user.Password = _passwordHasher.HashPassword(user, user.Password);
                }
            }

            _dbContext.SaveChanges();
            Console.WriteLine("Passwords hashed successfully.");
        }

        private bool IsPasswordHashed(string password)
        {
            return password.StartsWith("AQAAAA"); // Identity hashed passwords start with this
        }
    }
}
