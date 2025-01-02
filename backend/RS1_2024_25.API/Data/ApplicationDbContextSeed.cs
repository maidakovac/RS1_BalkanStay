using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Helpers;

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
                new City { ID = 3, Name = "Third City", CountryId = 1 },
                new City { ID = 4, Name = "Four City", CountryId = 4 }

             );

            modelBuilder.Entity<Country>().HasData
            (
               new Country { ID = 1, Name = "Example Country1" },
               new Country { ID = 2, Name = "Example Country2" },
               new Country { ID = 3, Name = "Example Country3" },
               new Country { ID = 4, Name = "Example Country4" }

            );


            modelBuilder.Entity<MyAppUser>().HasData
            (
                new MyAppUser
                {
                    UserID = 1,
                    Email = "manager1@example.com",
                    Phone = "123-456-7891",
                    Image = new byte[0],
                    CityID = 1,
                    GenderID = 1
                },
                new MyAppUser
                {
                    UserID = 2,
                    Email = "manager1@example.com",
                    Phone = "123-456-7891",
                    Image = new byte[0],
                    CityID = 2,
                    GenderID = 1
                },
                new MyAppUser
                {
                    UserID = 3,
                    Email = "manager1@example.com",
                    Phone = "123-456-6666",
                    Image = new byte[0],
                    CityID = 3,
                    GenderID = 2
                },
                new MyAppUser
                {
                    UserID = 4,
                    Email = "manager1@example.com",
                    Phone = "123-456-8888",
                    Image = new byte[0],
                    CityID = 4,
                    GenderID = 2
                },

                new MyAppUser
                {
                    UserID = 5,
                    Email = "manager5@example.com",
                    Phone = "123-456-7777",
                    Image = new byte[0],
                    CityID = 1,
                    GenderID = 1
                }

            );

            modelBuilder.Entity<Administrator>().HasData
            (
                new Administrator { AdministratorID = 1 },
                new Administrator { AdministratorID = 2 },
                new Administrator { AdministratorID = 3 },
                new Administrator { AdministratorID = 4 },
                new Administrator { AdministratorID = 5 },
                new Administrator { AdministratorID = 6 },
                new Administrator { AdministratorID = 7 }
            );

            modelBuilder.Entity<Account>().HasData
            (
                new Account { AccountID = 1, Username = "izellapin", Password = "xxxx", FirstName = "izel", LastName = "repuh", MyAppUserID = 1 },
                new Account { AccountID = 2, Username = "maidakcv", Password = "yyyy", FirstName = "maida", LastName = "kovac", MyAppUserID = 2 },
                new Account { AccountID = 3, Username = "usernameexample", Password = "zzzz**", FirstName = "user", LastName = "userlastname", MyAppUserID = 3 },
                new Account { AccountID = 4, Username = "example", Password = "hhhh", FirstName = "example", LastName = "examplelastname", MyAppUserID = 4 },
                new Account { AccountID = 5, Username = "examplexxx", Password = "ggggXX", FirstName = "exampleXX", LastName = "examplelastnameXXX", MyAppUserID = 5 }

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
               }



            );
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
                new ApartmentToiletry { ApartmentToiletryID = 1, ApartmentId = 1, ToiletryID= 1},
                new ApartmentToiletry { ApartmentToiletryID = 2, ApartmentId = 2, ToiletryID= 2},
                new ApartmentToiletry { ApartmentToiletryID = 3, ApartmentId = 3, ToiletryID= 3},
                new ApartmentToiletry { ApartmentToiletryID = 4, ApartmentId = 4, ToiletryID= 4},
                new ApartmentToiletry { ApartmentToiletryID = 5, ApartmentId = 4, ToiletryID= 5}
                

            );


        }
    }
}
