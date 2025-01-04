namespace RS1_2024_25.API.ViewModel
{
    public class OwnerUpdateVM
    {
        public int AccountID { get; set; } // Identifikator korisnika (obavezno)

        public string? FirstName { get; set; } // Opcionalna ažuriranja
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? CityID { get; set; } // Grad može biti promijenjen
        public int? GenderID { get; set; } // Spol može biti promijenjen
        public byte[]? Image { get; set; } // Opcionalno ažuriranje slike
    }

}
