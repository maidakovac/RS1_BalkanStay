using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data.Models.Auth;

namespace RS1_2024_25.API.Data
{
    public partial class ApplicationDbContextSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyAppUser>().HasData(
                new MyAppUser
                {
                    UserID = 1,
                    Email = "manager1@example.com",
                    Phone = "123-456-7891",
                    Image = "manager1.jpg",
                    CityID = 1,
                    GenderID = null
                },
                new MyAppUser
                {
                    UserID = 2,
                    Email = "manager1@example.com",
                    Phone = "123-456-7891",
                    Image = "manager1.jpg",
                    CityID = 1,
                    GenderID = null
                }
                

);


            modelBuilder.Entity<Administrator>().HasData(
                new Administrator { AdministratorID = 1 },
                new Administrator { AdministratorID = 2 },
                new Administrator { AdministratorID = 3 },
                new Administrator { AdministratorID = 4 },
                new Administrator { AdministratorID = 5 },
                new Administrator { AdministratorID = 6 },
                new Administrator { AdministratorID = 7 }
            );

            modelBuilder.Entity<Account>().HasData(
                new Account { AccountID = 1, Username = "izellapin", Password = "xxxx" ,FirstName = "izel", LastName = "repuh", MyAppUserID = 1},
                new Account { AccountID = 2, Username = "maidakcv", Password = "yyyy" ,FirstName = "maida", LastName = "kovac", MyAppUserID = 1 },
                new Account { AccountID = 3, Username = "usernameexample", Password = "zzzz**" ,FirstName = "user", LastName = "userlastname", MyAppUserID = 2 },
                new Account { AccountID = 4, Username = "example", Password = "hhhh" ,FirstName = "example", LastName = "examplelastname", MyAppUserID = 3 },
                new Account { AccountID = 5, Username = "examplexxx", Password = "ggggXX" ,FirstName = "exampleXX", LastName = "examplelastnameXXX", MyAppUserID = 4 }
               
            );
        }
    }
}
