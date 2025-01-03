using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Helpers;
using System.Numerics;

namespace RS1_2024_25.API.Data
{
    public partial class ApplicationDbContextSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData
            (
                  new Gender { GenderID = 1, Name = "Male" },
                  new Gender { GenderID = 2, Name = "Female" }

            );

            modelBuilder.Entity<City>().HasData
             (
                new City { ID = 1, Name = "Example City", CountryId = 1 },
                new City { ID = 2, Name = "Another City", CountryId = 2 },
                new City { ID = 3, Name = "Third City", CountryId = 3 },
                new City { ID = 4, Name = "Four City", CountryId = 4 }

             );

            modelBuilder.Entity<Country>().HasData
            (
               new Country { ID = 1, Name = "Example Country1" },
               new Country { ID = 2, Name = "Example Country2" },
               new Country { ID = 3, Name = "Example Country3" },
               new Country { ID = 4, Name = "Example Country4" }

            );


            modelBuilder.Entity<Administrator>().HasData
           (
                 new Administrator
                 {
                     AccountID = 1,
                     Username = "admin",
                     Password = "AdminPass",
                     FirstName = "Admin",
                     LastName = "User",
                     Email = "admin@example.com"
                 },
                 new Administrator
                 {
                     AccountID = 2,
                     Username = "superadmin",
                     Password = "SuperPass",
                     FirstName = "Super",
                     LastName = "Admin",
                     Email = "superadmin@example.com"
                 },
                 new Administrator
                 {
                     AccountID = 3,
                     Username = "izelrepuh",
                     Password = "SuperPass",
                     FirstName = "Izel",
                     LastName = "Repuh",
                     Email = "izelrepuh@example.com"
                 },
                new Administrator
                {
                    AccountID = 4,
                    Username = "amaromer",
                    Password = "SuperAmar",
                    FirstName = "Amar",
                    LastName = "Omer",
                    Email = "amaromer@example.com"
                }
           );


            modelBuilder.Entity<User>().HasData(
                  new User
                  {
                      AccountID = 5,
                      Username = "johndoe",
                      Email = "johndoe@example.com",
                      Password = "JohnPass",
                      FirstName = "John",
                      LastName = "Doe",
                      Phone = "+38761000111",
                      GenderID = 1,
                      CityID = 1,
                      Image = null,
                      CreatedAt = DateTime.UtcNow
                  },

                  new User
                  {
                      AccountID = 6,
                      Username = "janedoe",
                      Email = "janedoe@example.com",
                      Password = "JanePass",
                      FirstName = "Jane",
                      LastName = "Doe",
                      Phone = "+38761000222",
                      GenderID = 2,
                      CityID = 2,
                      Image = null,
                      CreatedAt = DateTime.UtcNow
                  },

                  new User
                  {
                      AccountID = 7,
                      Username = "xxxxx",
                      Email = "xxxx@example.com",
                      Password = "xxxxx",
                      FirstName = "Xkorisnik",
                      LastName = "PKorisnik",
                      Phone = "+38761000222",
                      GenderID = 1,
                      CityID = 3,
                      Image = null,
                      CreatedAt = DateTime.UtcNow
                  },

                  new User
                  {
                      AccountID = 8,
                      Username = "yyyy",
                      Email = "yyyy@example.com",
                      Password = "YYYXX",
                      FirstName = "YYKorisnik",
                      LastName = "YYPrezime",
                      Phone = "+38761000222",
                      GenderID = 2,
                      CityID = 4,
                      Image = null,
                      CreatedAt = DateTime.UtcNow
                  }
            );



            modelBuilder.Entity<Owner>().HasData
            (
                new Owner
                {
                    AccountID = 9,
                    FirstName = "Izel",
                    LastName = "Repuh",
                    Username = "Izel",
                    Email = "izel@gmail.com",
                    Password = "Izel",
                    Phone = "061-000-111",
                    GenderID = 2,
                    CityID = 1,
                    Image = new byte[0],
                    CreatedAt = DateTime.UtcNow

                },
                 new Owner
                 {
                     AccountID = 10,
                     FirstName = "Maida",
                     LastName = "Kovac",
                     Username = "Maida",
                     Email = "maida@gmail.com",
                     Password = "Maida",
                     Phone = "061-000-222",
                     GenderID = 2,
                     CityID = 2,
                     Image = new byte[0],
                     CreatedAt = DateTime.UtcNow,

                 },
                 new Owner
                 {
                     AccountID = 11,
                     FirstName = "Admin",
                     LastName = "Admin",
                     Username = "Admin",
                     Email = "owner@gmail.com",
                     Password = "Admin",
                     Phone = "061-000-333",
                     GenderID = 1,
                     CityID = 3,
                     Image = new byte[0],
                     CreatedAt = DateTime.UtcNow,

                 }


            );


            modelBuilder.Entity<Apartment>().HasData
            (
               new Apartment
               {
                   ApartmentId = 1,
                   Name = "Apartment Marshal",
                   Description = "opis neki",
                   Adress = "Adresa 1",
                   PricePerNight = 50,
                   CityId = 1
               },
               new Apartment
               {
                   ApartmentId = 2,
                   Name = "Apartment Charm",
                   Description = "opis neki",
                   Adress = "Adresa 2",
                   PricePerNight = 70,
                   CityId = 2
               },
               new Apartment
               {
                   ApartmentId = 3,
                   Name = "Apartment Sun",
                   Description = "opis neki",
                   Adress = "Adresa 3",
                   PricePerNight = 50,
                   CityId = 3
               },
               new Apartment
               {
                   ApartmentId = 4,
                   Name = "Apartment Exclusive",
                   Description = "opis neki",
                   Adress = "Adresa 4",
                   PricePerNight = 150,
                   CityId = 4
               });



            modelBuilder.Entity<Rule>().HasData
           (
               new Rule { RuleID = 1, RuleText = "Zabranjeno pusenje" },
               new Rule { RuleID = 2, RuleText = "Zabranjene zabave" },
               new Rule { RuleID = 3, RuleText = "Dozvoljeni ljubimci" },
               new Rule { RuleID = 4, RuleText = "Zabranjeno prekoracenje kapaciteta osoba" },
               new Rule { RuleID = 5, RuleText = "Zabranjeno NESTO" }
           );

            modelBuilder.Entity<ApartmentRule>().HasData
            (
                new ApartmentRule { ApartmentRuleID = 1, ApartmentId = 1, RuleID = 1 },
                new ApartmentRule { ApartmentRuleID = 2, ApartmentId = 2, RuleID = 2 },
                new ApartmentRule { ApartmentRuleID = 3, ApartmentId = 3, RuleID = 3 },
                new ApartmentRule { ApartmentRuleID = 4, ApartmentId = 1, RuleID = 4 },
                new ApartmentRule { ApartmentRuleID = 5, ApartmentId = 4, RuleID = 5 }
            );


            modelBuilder.Entity<Amenity>().HasData
              (
                  new Amenity { AmenityID = 1, AmenityText = "Besplatan parking" },
                  new Amenity { AmenityID = 2, AmenityText = "Klima uređaj" },
                  new Amenity { AmenityID = 3, AmenityText = "Veš mašina" },
                  new Amenity { AmenityID = 4, AmenityText = "Pogled s terase" },
                  new Amenity { AmenityID = 5, AmenityText = "Bazen" },
                  new Amenity { AmenityID = 6, AmenityText = "Sauna" }

              );

            modelBuilder.Entity<ApartmentAmenity>().HasData
            (
                new ApartmentAmenity { ApartmentAmenityID = 1, ApartmentId = 1, AmenityID = 1 },
                new ApartmentAmenity { ApartmentAmenityID = 2, ApartmentId = 2, AmenityID = 2 },
                new ApartmentAmenity { ApartmentAmenityID = 3, ApartmentId = 3, AmenityID = 3 },
                new ApartmentAmenity { ApartmentAmenityID = 4, ApartmentId = 4, AmenityID = 4 },
                new ApartmentAmenity { ApartmentAmenityID = 5, ApartmentId = 2, AmenityID = 5 }
            );


            modelBuilder.Entity<Toiletry>().HasData
             (
                 new Toiletry { ToiletryID = 1, Name = "Sapun" },
                 new Toiletry { ToiletryID = 2, Name = "Šampon" },
                 new Toiletry { ToiletryID = 3, Name = "Regenerator" },
                 new Toiletry { ToiletryID = 4, Name = "Fen" },
                 new Toiletry { ToiletryID = 5, Name = "Peškiri" }

             );

            modelBuilder.Entity<ApartmentToiletry>().HasData
            (
                new ApartmentToiletry { ApartmentToiletryID = 1, ApartmentId = 1, ToiletryID = 1 },
                new ApartmentToiletry { ApartmentToiletryID = 2, ApartmentId = 2, ToiletryID = 2 },
                new ApartmentToiletry { ApartmentToiletryID = 3, ApartmentId = 3, ToiletryID = 3 },
                new ApartmentToiletry { ApartmentToiletryID = 4, ApartmentId = 4, ToiletryID = 4 },
                new ApartmentToiletry { ApartmentToiletryID = 5, ApartmentId = 4, ToiletryID = 5 }


            );



        }
    }
}

