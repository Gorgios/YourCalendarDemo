using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Terminarz.Enum;
using Terminarz.Validators;

namespace Terminarz.Models
{
    public abstract class Task
    {
        public int ID { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Nazwa jest za krotka (minimum 3 znaki)")]
        [MaxLength(20, ErrorMessage = "Nazwa jest za dluga (maksymalnie 20 znakow)")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Priorytet")]
        public Priority? Priority { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data wydarzenia")]
        [FutureDate(ErrorMessage="Data wczesniejsza")]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Czas wydarzenia")]
        public DateTime Time { get; set; }
        
        [Display(Name = "Opis")]
        [StringLength(200,ErrorMessage ="Za dlugi opis")]
        public string Description { get; set; }
        [Display(Name="Godzina wydarzenia")]
        public string DateTime
        {
            get
            {
                return Date.ToString("dd MMMM yyyy") + " " + Time.ToString("H:mm");
            }
        }
    }
}
