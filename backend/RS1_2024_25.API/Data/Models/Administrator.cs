﻿using System.Text.Json.Serialization;

namespace RS1_2024_25.API.Data.Models.Auth
{
    public class Administrator:Account
    {
        [JsonIgnore]
        public byte[]? Image { get; set; } // Opcionalno, ako se slika dodaje prilikom kreiranja

    }
}
