using System.ComponentModel.DataAnnotations;

namespace RS1_2024_25.API.ViewModel
{
    public class AdministratorInsertViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; } // Lozinku treba hashirati prije spremanja
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[]? Image { get; set; } // Opcionalna slika
    }

}
