using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Terminarz.Models
{
    public class Contact
    {
        public int ID { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Nazwa kontaktu jest za krotka")]
        [MaxLength(20, ErrorMessage = "Nazwa kontaktu jest za dluga")]
        [Display(Name = "Nazwa kontaktu")]
        public string Name { get; set; }
        [Required]
        [Range(100000000,999999999,ErrorMessage ="Numer telefonu musi miec 9 cyfr")]
        [Display(Name ="Numer telefonu")]
        public int Number { get; set; }
        [Url]
        [Display(Name = "Url zdjecia")]
        public string PhotoUrl { get; set; }

        public IEnumerable<Call> Calls { get; set; }
        public IEnumerable<Meeting> Meetings { get; set; }
    }
}
