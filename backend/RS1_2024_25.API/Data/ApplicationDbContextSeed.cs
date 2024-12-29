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
                  new Gender { GenderID = 1, Name = "Male"},
                  new Gender { GenderID = 2, Name = "Female"}

            );

            modelBuilder.Entity<City>().HasData
             (
                new City { ID = 1, Name = "Example City", CountryId = 1 },
                new City { ID = 2, Name = "Another City", CountryId = 1 },
                new City { ID = 3, Name = "Third City", CountryId = 1 },
                new City { ID = 4, Name = "Four City", CountryId = 1 }

             );

            modelBuilder.Entity<Country>().HasData
            (
               new Country { ID = 1, Name = "Example Country1"},
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
                    GenderID = null
                },
                new MyAppUser
                {
                    UserID = 2,
                    Email = "manager1@example.com",
                    Phone = "123-456-7891",
                    Image = new byte[0],
                    CityID = 2,
                    GenderID = null
                },
                new MyAppUser
                {
                    UserID = 3,
                    Email = "manager1@example.com",
                    Phone = "123-456-6666",
                    Image = new byte[0],
                    CityID = 3,
                    GenderID = null
                },
                new MyAppUser
                { UserID = 4,
                    Email = "manager1@example.com",
                    Phone = "123-456-8888",
                    Image = new byte[0],
                    CityID = 4,
                    GenderID = null
                },

                new MyAppUser
                {
                    UserID = 5, 
                    Email = "manager5@example.com",
                    Phone = "123-456-7777",
                    Image = new byte[0],
                    CityID = 1, 
                    GenderID = null
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
                    new Account { AccountID = 1, Username = "izellapin", Password = "xxxx" ,FirstName = "izel", LastName = "repuh", MyAppUserID = 1},
                    new Account { AccountID = 2, Username = "maidakcv", Password = "yyyy" ,FirstName = "maida", LastName = "kovac", MyAppUserID = 2 },
                    new Account { AccountID = 3, Username = "usernameexample", Password = "zzzz**" ,FirstName = "user", LastName = "userlastname", MyAppUserID = 3 },
                    new Account { AccountID = 4, Username = "example", Password = "hhhh" ,FirstName = "example", LastName = "examplelastname", MyAppUserID = 4 },
                    new Account { AccountID = 5, Username = "examplexxx", Password = "ggggXX" ,FirstName = "exampleXX", LastName = "examplelastnameXXX", MyAppUserID = 5 }
               
                );
        }
    }
}
