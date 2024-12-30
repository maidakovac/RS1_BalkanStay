using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RS1_2024_25.API.Data.Models.Auth;

public class MyAppUser
{
        [Key]
        public int UserID { get; set; } // Primary key (AutoNumber)

        [Required]
        [EmailAddress] // Ensures a valid email format
        public string Email { get; set; }

        [Required]
        [Phone] // Ensures a valid phone number format
        public string Phone { get; set; }
        // Limits the maximum length of the image URL
        public byte[] Image { get; set; }

        // Foreign Key to City
        [ForeignKey("City")]
        public int? CityID { get; set; }

        // Foreign Key to Gender
        [ForeignKey("Gender")]
        public int? GenderID { get; set; }

        // Navigation Properties
        public virtual City City { get; set; }
        public virtual Gender Gender { get; set; }

         public Account Account { get; set; }

         public List<Favorite> Favorites { get; set; }
         public List<Review> Reviews { get; set; }

        public List<Reservation> Reservations { get; set; }



}

    /*
     
     Ako sistem nije zamišljen da podržava česte promjene rola i 
     ako se dodavanje novih rola svodi na manje promjene u kodu, 
    tada može biti dovoljno koristiti boolean polja kao što su IsAdmin, IsManager itd. 
    
    Ovaj pristup je jednostavan i efektivan u situacijama gdje su role stabilne i unaprijed definirane.

    Međutim, glavna prednost korištenja role entiteta dolazi do izražaja kada aplikacija potencijalno raste i 
    zahtjeva kompleksnije role i ovlaštenja. U scenarijima gdje se očekuje veći broj različitih rola ili kompleksniji 
    sistem ovlaštenja, dodavanje nove bool varijable može postati nepraktično i otežati održavanje.

    Dakle, za stabilne sisteme s manjim brojem fiksnih rola, boolean polja su sasvim razumno rješenje.
     */

