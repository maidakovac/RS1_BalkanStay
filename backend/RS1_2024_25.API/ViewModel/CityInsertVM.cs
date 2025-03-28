﻿using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.ViewModel
{
    public class CityInsertVM
    {
        public string Name { get; set; }

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public List<ApartmentInsertVM>? Apartments { get; set; } = new List<ApartmentInsertVM>();
    }
}

