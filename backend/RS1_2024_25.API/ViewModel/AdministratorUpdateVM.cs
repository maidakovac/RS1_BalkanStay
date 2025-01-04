using System.ComponentModel.DataAnnotations;

namespace RS1_2024_25.API.ViewModel
{
    public class AdministratorUpdateViewModel
    {
        public int AccountID { get; set; } // ID administratora
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte[]? Image { get; set; } // Opcionalna slika za ažuriranje
    }

}
