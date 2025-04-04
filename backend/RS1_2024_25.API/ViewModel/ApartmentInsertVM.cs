﻿using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.ViewModel
{
    public class ApartmentInsertVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public int PricePerNight { get; set; }
        public int CityId { get; set; }
        [ForeignKey(nameof(Owner))]
        public int? AccountID { get; set; } // Koristi se AccountID, jer User nasleđuje Account
        public Owner? Account { get; set; }

    }
}
