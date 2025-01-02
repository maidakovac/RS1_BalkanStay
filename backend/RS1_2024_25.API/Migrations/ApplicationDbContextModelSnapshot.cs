﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RS1_2024_25.API.Data;

#nullable disable

namespace RS1_2024_25.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RS1_2024_25.API.Data.Amenity", b =>
                {
                    b.Property<int>("AmenityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AmenityID"));

                    b.Property<int>("AmenityText")
                        .HasColumnType("int");

                    b.HasKey("AmenityID");

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Apartment", b =>
                {
                    b.Property<int>("ApartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApartmentId"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PricePerNight")
                        .HasColumnType("int");

                    b.HasKey("ApartmentId");

                    b.HasIndex("CityId");

                    b.ToTable("Apartments");

                    b.HasData(
                        new
                        {
                            ApartmentId = 1,
                            Adress = "Adresa 1",
                            CityId = 1,
                            Description = "opis neki",
                            Name = "Apartment Marshal",
                            PricePerNight = 50
                        },
                        new
                        {
                            ApartmentId = 2,
                            Adress = "Adresa 2",
                            CityId = 2,
                            Description = "opis neki",
                            Name = "Apartment Charm",
                            PricePerNight = 70
                        },
                        new
                        {
                            ApartmentId = 3,
                            Adress = "Adresa 3",
                            CityId = 3,
                            Description = "opis neki",
                            Name = "Apartment Sun",
                            PricePerNight = 50
                        },
                        new
                        {
                            ApartmentId = 4,
                            Adress = "Adresa 4",
                            CityId = 4,
                            Description = "opis neki",
                            Name = "Apartment Exclusive",
                            PricePerNight = 150
                        });
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.ApartmentAmenity", b =>
                {
                    b.Property<int>("ApartmentAmenityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApartmentAmenityID"));

                    b.Property<int>("AmenityID")
                        .HasColumnType("int");

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.HasKey("ApartmentAmenityID");

                    b.HasIndex("AmenityID");

                    b.HasIndex("ApartmentId");

                    b.ToTable("ApartmentAmenities");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.ApartmentImage", b =>
                {
                    b.Property<int>("ApartmentImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApartmentImageID"));

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<int>("ImageID")
                        .HasColumnType("int");

                    b.HasKey("ApartmentImageID");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("ImageID");

                    b.ToTable("ApartmentImages");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.ApartmentRule", b =>
                {
                    b.Property<int>("ApartmentRuleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApartmentRuleID"));

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<int>("RuleID")
                        .HasColumnType("int");

                    b.HasKey("ApartmentRuleID");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("RuleID");

                    b.ToTable("ApartmentRules");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.ApartmentToiletry", b =>
                {
                    b.Property<int>("ApartmentToiletryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApartmentToiletryID"));

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<int>("ToiletryID")
                        .HasColumnType("int");

                    b.HasKey("ApartmentToiletryID");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("ToiletryID");

                    b.ToTable("ApartmentToiletries");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Favorite", b =>
                {
                    b.Property<int>("FavoriteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FavoriteID"));

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<int>("MyAppUserUserID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("FavoriteID");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("MyAppUserUserID");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Image", b =>
                {
                    b.Property<int>("ImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageID"));

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ImageID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.Auth.Account", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MyAppUserID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountID");

                    b.HasIndex("MyAppUserID")
                        .IsUnique();

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountID = 1,
                            FirstName = "izel",
                            LastName = "repuh",
                            MyAppUserID = 1,
                            Password = "xxxx",
                            Username = "izellapin"
                        },
                        new
                        {
                            AccountID = 2,
                            FirstName = "maida",
                            LastName = "kovac",
                            MyAppUserID = 2,
                            Password = "yyyy",
                            Username = "maidakcv"
                        },
                        new
                        {
                            AccountID = 3,
                            FirstName = "user",
                            LastName = "userlastname",
                            MyAppUserID = 3,
                            Password = "zzzz**",
                            Username = "usernameexample"
                        },
                        new
                        {
                            AccountID = 4,
                            FirstName = "example",
                            LastName = "examplelastname",
                            MyAppUserID = 4,
                            Password = "hhhh",
                            Username = "example"
                        },
                        new
                        {
                            AccountID = 5,
                            FirstName = "exampleXX",
                            LastName = "examplelastnameXXX",
                            MyAppUserID = 5,
                            Password = "ggggXX",
                            Username = "examplexxx"
                        });
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.Auth.Administrator", b =>
                {
                    b.Property<int>("AdministratorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdministratorID"));

                    b.HasKey("AdministratorID");

                    b.ToTable("Administrators");

                    b.HasData(
                        new
                        {
                            AdministratorID = 1
                        },
                        new
                        {
                            AdministratorID = 2
                        },
                        new
                        {
                            AdministratorID = 3
                        },
                        new
                        {
                            AdministratorID = 4
                        },
                        new
                        {
                            AdministratorID = 5
                        },
                        new
                        {
                            AdministratorID = 6
                        },
                        new
                        {
                            AdministratorID = 7
                        });
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.Auth.MyAppUser", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GenderID")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("CityID");

                    b.HasIndex("GenderID");

                    b.ToTable("MyAppUsers");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            CityID = 1,
                            Email = "manager1@example.com",
                            Image = new byte[0],
                            Phone = "123-456-7891"
                        },
                        new
                        {
                            UserID = 2,
                            CityID = 2,
                            Email = "manager1@example.com",
                            Image = new byte[0],
                            Phone = "123-456-7891"
                        },
                        new
                        {
                            UserID = 3,
                            CityID = 3,
                            Email = "manager1@example.com",
                            Image = new byte[0],
                            Phone = "123-456-6666"
                        },
                        new
                        {
                            UserID = 4,
                            CityID = 4,
                            Email = "manager1@example.com",
                            Image = new byte[0],
                            Phone = "123-456-8888"
                        },
                        new
                        {
                            UserID = 5,
                            CityID = 1,
                            Email = "manager5@example.com",
                            Image = new byte[0],
                            Phone = "123-456-7777"
                        });
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.Auth.MyAuthenticationToken", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MyAppUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RecordedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MyAppUserId");

                    b.ToTable("MyAuthenticationTokens");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.Auth.TwoFactorAuth", b =>
                {
                    b.Property<int>("TwoFactorAuthId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TwoFactorAuthId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("AuthToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2");

                    b.HasKey("TwoFactorAuthId");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("TwoFactorAuths");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CountryId = 1,
                            Name = "Example City"
                        },
                        new
                        {
                            ID = 2,
                            CountryId = 2,
                            Name = "Another City"
                        },
                        new
                        {
                            ID = 3,
                            CountryId = 1,
                            Name = "Third City"
                        },
                        new
                        {
                            ID = 4,
                            CountryId = 4,
                            Name = "Four City"
                        });
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Example Country1"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Example Country2"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Example Country3"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Example Country4"
                        });
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.Gender", b =>
                {
                    b.Property<int>("GenderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenderID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenderID");

                    b.ToTable("Gender");

                    b.HasData(
                        new
                        {
                            GenderID = 1,
                            Name = "Male"
                        },
                        new
                        {
                            GenderID = 2,
                            Name = "Female"
                        });
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Owner", b =>
                {
                    b.Property<int>("OwnerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OwnerID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OwnerID");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.OwnerApartment", b =>
                {
                    b.Property<int>("OwnerApartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OwnerApartmentID"));

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerID")
                        .HasColumnType("int");

                    b.HasKey("OwnerApartmentID");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("OwnerID");

                    b.ToTable("OwnerApartments");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.OwnerReview", b =>
                {
                    b.Property<int>("OwnerReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OwnerReviewID"));

                    b.Property<int>("MyAppUserUserID")
                        .HasColumnType("int");

                    b.Property<int>("OwnerID")
                        .HasColumnType("int");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("OwnerReviewID");

                    b.HasIndex("MyAppUserUserID");

                    b.HasIndex("OwnerID");

                    b.ToTable("OwnerReviews");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationID"));

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MyAppUserUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ReservationID");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("MyAppUserUserID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewID"));

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MyAppUserUserID")
                        .HasColumnType("int");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ReviewID");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("MyAppUserUserID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Rule", b =>
                {
                    b.Property<int>("RuleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RuleID"));

                    b.Property<string>("RuleText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RuleID");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Toiletry", b =>
                {
                    b.Property<int>("ToiletryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ToiletryID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ToiletryID");

                    b.ToTable("Toiletries");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Apartment", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Models.City", "City")
                        .WithMany("Apartments")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("City");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.ApartmentAmenity", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Amenity", "Amenity")
                        .WithMany()
                        .HasForeignKey("AmenityID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RS1_2024_25.API.Data.Apartment", "Apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.ApartmentImage", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Apartment", "Apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RS1_2024_25.API.Data.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Apartment");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.ApartmentRule", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Apartment", "Apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RS1_2024_25.API.Data.Rule", "Rule")
                        .WithMany()
                        .HasForeignKey("RuleID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Apartment");

                    b.Navigation("Rule");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.ApartmentToiletry", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Apartment", "Apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RS1_2024_25.API.Data.Toiletry", "Toiletry")
                        .WithMany()
                        .HasForeignKey("ToiletryID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Apartment");

                    b.Navigation("Toiletry");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Favorite", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Apartment", "Apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RS1_2024_25.API.Data.Models.Auth.MyAppUser", "MyAppUser")
                        .WithMany()
                        .HasForeignKey("MyAppUserUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Apartment");

                    b.Navigation("MyAppUser");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.Auth.Account", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Models.Auth.MyAppUser", "MyAppUser")
                        .WithOne("Account")
                        .HasForeignKey("RS1_2024_25.API.Data.Models.Auth.Account", "MyAppUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MyAppUser");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.Auth.MyAppUser", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("RS1_2024_25.API.Data.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("City");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.Auth.MyAuthenticationToken", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Models.Auth.MyAppUser", "MyAppUser")
                        .WithMany()
                        .HasForeignKey("MyAppUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MyAppUser");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.Auth.TwoFactorAuth", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Models.Auth.Account", "Account")
                        .WithOne("TwoFactorAuth")
                        .HasForeignKey("RS1_2024_25.API.Data.Models.Auth.TwoFactorAuth", "AccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.City", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.OwnerApartment", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Apartment", "Apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RS1_2024_25.API.Data.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Apartment");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.OwnerReview", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Models.Auth.MyAppUser", "MyAppUser")
                        .WithMany()
                        .HasForeignKey("MyAppUserUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RS1_2024_25.API.Data.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MyAppUser");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Reservation", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Apartment", "Apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RS1_2024_25.API.Data.Models.Auth.MyAppUser", "MyAppUser")
                        .WithMany()
                        .HasForeignKey("MyAppUserUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Apartment");

                    b.Navigation("MyAppUser");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Review", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Apartment", "Apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RS1_2024_25.API.Data.Models.Auth.MyAppUser", "MyAppUser")
                        .WithMany()
                        .HasForeignKey("MyAppUserUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Apartment");

                    b.Navigation("MyAppUser");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.Auth.Account", b =>
                {
                    b.Navigation("TwoFactorAuth")
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.Auth.MyAppUser", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.City", b =>
                {
                    b.Navigation("Apartments");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
