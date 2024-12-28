namespace RS1_2024_25.API.Endpoints.DataSeed;

using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Helper.Api;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

[Route("data-seed")]
public class DataSeedGenerateEndpoint(ApplicationDbContext db)
    : MyEndpointBaseAsync
    .WithoutRequest
    .WithResult<string>
{
    [HttpPost]
    public override async Task<string> HandleAsync(CancellationToken cancellationToken = default)
    {
        if (db.MyAppUsers.Any())
        {
            throw new Exception("Podaci su vec generisani");
        }
        // Kreiranje država
        var countries = new List<Country>
        {
            new Country { Name = "Bosnia and Herzegovina" },
            new Country { Name = "Croatia" },
            new Country { Name = "Germany" },
            new Country { Name = "Austria" },
            new Country { Name = "USA" }
        };

        // Kreiranje gradova
        var cities = new List<City>
        {
            new City { Name = "Sarajevo", Country = countries[0] },
            new City { Name = "Mostar", Country = countries[0] },
            new City { Name = "Zagreb", Country = countries[1] },
            new City { Name = "Berlin", Country = countries[2] },
            new City { Name = "Vienna", Country = countries[3] },
            new City { Name = "New York", Country = countries[4] },
            new City { Name = "Los Angeles", Country = countries[4] }
        };

        // Kreiranje korisnika s ulogama
        var users = new List<MyAppUser>
        {
            new MyAppUser
            {
                Email = "admin1@example.com",
                Phone = "123-456-7890",
                Image = "admin1.jpg",
                City = cities[0],
                GenderID = null
            },
            new MyAppUser
            {
                Email = "manager1@example.com",
                Phone = "123-456-7891",
                Image = "manager1.jpg",
                City = cities[0],
                GenderID = null
            },
            new MyAppUser
            {
                Email = "user1@example.com",
                Phone = "123-456-7892",
                Image = "user1.jpg",
                City = cities[1],
                GenderID = null
            },
            new MyAppUser
            {
                Email = "user2@example.com",
                Phone = "123-456-7893",
                Image = "user2.jpg",
                City = cities[2],
                GenderID = null
            }
        };

        // Dodavanje podataka u bazu
        await db.Countries.AddRangeAsync(countries, cancellationToken);
        await db.Cities.AddRangeAsync(cities, cancellationToken);
        await db.MyAppUsers.AddRangeAsync(users, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);

        return "Data generation completed successfully.";
    }
}
