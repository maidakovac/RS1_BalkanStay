using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Helpers;
using System.Numerics;
using ImageSeeder = RS1_2024_25.API.Data.Models.ImageSeeder;

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
                new City { ID = 1, Name = "Sarajevo", CountryId = 1 },
                new City { ID = 2, Name = "Mostar", CountryId = 1 },
                new City { ID = 3, Name = "Tuzla", CountryId = 1 },
                new City { ID = 4, Name = "Zagreb", CountryId = 2 },
                new City { ID = 5, Name = "Rijeka", CountryId = 2 },
                new City { ID = 6, Name = "Pula", CountryId = 2 },
                new City { ID = 7, Name = "Beograd", CountryId = 3 },
                new City { ID = 8, Name = "Novi Sad", CountryId = 3 },
                new City { ID = 9, Name = "Skopje", CountryId = 4 },
                new City { ID = 10, Name = "Ohrid", CountryId = 4 },
                new City { ID = 11, Name = "Sofia", CountryId = 5 },
                new City { ID = 12, Name = "Varna", CountryId = 5 },
                new City { ID = 13, Name = "Budva", CountryId = 6 },
                new City { ID = 14, Name = "Bar", CountryId = 6 },
                new City { ID = 15, Name = "Kotor", CountryId = 6 },
                new City { ID = 16, Name = "Tirana", CountryId = 7 },
                new City { ID = 17, Name = "Vlorë", CountryId = 7 },
                new City { ID = 18, Name = "Durrës", CountryId = 7 },
                new City { ID = 19, Name = "Atena", CountryId = 8 },
                new City { ID = 20, Name = "Thessaloniki", CountryId = 8 },
                new City { ID = 21, Name = "Patras", CountryId = 8 },
                new City { ID = 22, Name = "Corfu", CountryId = 8 }

             );

            modelBuilder.Entity<Country>().HasData
            (
               new Country { ID = 1, Name = "Bosna i Hercegovina" },
               new Country { ID = 2, Name = "Hrvatska" },
               new Country { ID = 3, Name = "Srbija" },
               new Country { ID = 4, Name = "Makedonija" },
               new Country { ID = 5, Name = "Bugarska" },
               new Country { ID = 6, Name = "Crna Gora" },
               new Country { ID = 7, Name = "Albanija" },
               new Country { ID = 8, Name = "Grčka" }

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
                      CreatedAt = DateTime.UtcNow,

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
                  Description = "A stylish and modern apartment in a prime location, perfect for travelers.",
                  Adress = "Adresa 1",
                  PricePerNight = 50,
                  CityId = 1
              },
                new Apartment
                {
                    ApartmentId = 2,
                    Name = "Apartment Charm",
                    Description = "A cozy and charming space with elegant decor and a warm atmosphere.",
                    Adress = "Adresa 2",
                    PricePerNight = 70,
                    CityId = 2
                },
                new Apartment
                {
                    ApartmentId = 3,
                    Name = "Apartment Sun",
                    Description = "Bright and spacious apartment with plenty of natural light and a stunning view.",
                    Adress = "Adresa 3",
                    PricePerNight = 50,
                    CityId = 3
                },
                new Apartment
                {
                    ApartmentId = 4,
                    Name = "Apartment Exclusive",
                    Description = "A luxury apartment with high-end amenities, ideal for a premium experience.",
                    Adress = "Adresa 4",
                    PricePerNight = 150,
                    CityId = 4
                },

               new Apartment
               {
                   ApartmentId = 5,
                   Name = "Mountain View Lodge",
                   Description = "A cozy retreat with a breathtaking mountain view.",
                   Adress = "Bjelašnica 12",
                   PricePerNight = 80,
                   CityId = 6
               },
            new Apartment
            {
                ApartmentId = 6,
                Name = "Seaside Escape",
                Description = "A luxurious apartment right by the Adriatic Sea.",
                Adress = "Obala 45, Rijeka",
                PricePerNight = 120,
                CityId = 7
            },
            new Apartment
            {
                ApartmentId = 7,
                Name = "Urban Loft",
                Description = "Modern loft in the heart of the city, perfect for business travelers.",
                Adress = "Centar 22, Novi Sad",
                PricePerNight = 95,
                CityId = 8
            },
            new Apartment
            {
                ApartmentId = 8,
                Name = "Historic Downtown Apartment",
                Description = "Stay in a beautifully restored historic building in the old town.",
                Adress = "Stari Grad 17, Skopje",
                PricePerNight = 70,
                CityId = 10
            },
            new Apartment
            {
                ApartmentId = 9,
                Name = "Luxury Penthouse",
                Description = "Exclusive penthouse with a private terrace and panoramic city views.",
                Adress = "Skyline Tower, Athens",
                PricePerNight = 250,
                CityId = 19
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

            modelBuilder.Entity<ApartmentImage>().HasData
            (
                new ApartmentImage { ApartmentImageID = 1, ApartmentId = 1, ImageID = 1 },
                new ApartmentImage { ApartmentImageID = 2, ApartmentId = 2, ImageID = 2 },
                new ApartmentImage { ApartmentImageID = 3, ApartmentId = 3, ImageID = 3 } ,
                new ApartmentImage { ApartmentImageID = 4, ApartmentId = 4, ImageID = 4 },
                new ApartmentImage { ApartmentImageID = 5, ApartmentId = 5, ImageID = 5 },
                new ApartmentImage { ApartmentImageID = 6, ApartmentId = 6, ImageID = 1 },
                new ApartmentImage { ApartmentImageID = 7, ApartmentId = 7, ImageID = 2 },
                new ApartmentImage { ApartmentImageID = 8, ApartmentId = 8, ImageID = 3 },
                new ApartmentImage { ApartmentImageID = 9, ApartmentId = 9, ImageID = 4 }
            );



            modelBuilder.Entity<Image>().HasData(
            new Image
            {
                ImageID = 1,
                ImagePath = ImageSeeder.GetImagePath("/images/image2.jpg") // ❌ Wrong type (byte[])
            },
            new Image
            {
                ImageID = 2,
                ImagePath = ImageSeeder.GetImagePath("/images/room1.jpg") // ❌ Wrong type (byte[])
            },
            new Image
            {
                ImageID = 3,
                ImagePath = ImageSeeder.GetImagePath("/images/toilet2.jpg") // ❌ Wrong type (byte[])
            },
             new Image
             {
                 ImageID = 4,
                 ImagePath = ImageSeeder.GetImagePath("/images/room1.jpg") // ❌ Wrong type (byte[])
             },
            new Image
            {
                ImageID = 5,
                ImagePath = ImageSeeder.GetImagePath("/images/image2.jpg") // ❌ Wrong type (byte[])
            }
        );



            //modelBuilder.Entity<Image>().HasData(
            //      new Image
            //      {
            //          ImageID = 1,
            //          ImagePath = ImageSeeder.GetImageBytes("wwwroot/image2.jpg")
            //      },
            //      new Image
            //      {
            //          ImageID = 2,
            //          ImagePath = ImageSeeder.GetImageBytes("wwwroot/room1.jpg")
            //      },
            //      new Image
            //      {
            //          ImageID = 3,
            //          ImagePath = ImageSeeder.GetImageBytes("wwwroot/toilet2.jpg")
            //      }



            //);



        }
    }
}

