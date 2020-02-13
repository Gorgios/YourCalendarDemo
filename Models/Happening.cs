using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Terminarz.Enum;

namespace Terminarz.Models
{
    public class Happening : Task
    {
        [Required]
        [MinLength(3, ErrorMessage = "Nazwa miasta jest za krotka (minimum 3 znaki)")]
        [MaxLength(20, ErrorMessage = "Nazwa miasta jest za dluga (maksymalnie 20 znaków)")]
        [Display(Name="Miasto")]
        public string City { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Adres jest za krotki (minimum 3 znaki)")]
        [MaxLength(30, ErrorMessage = "Adres jest za dlugi (maksymalnie 30 znaków)")]
        [Display(Name="Adres")]
        public string Address { get; set; }
        
        [Required]
        [Display(Name="Rodzaj stroju")]
        public Suit? Suit { get; set; } 

        public string FullAddress
        {
            get
            {
                return Address + City;
            }
        }
    }
}
