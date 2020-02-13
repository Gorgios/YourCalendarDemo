using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Terminarz.Models
{
    public class Meeting : Happening
    {
        [Required]
        [Display(Name = "Kontakt")]
        public int ContactID { get; set; }
        public Contact Contact { get; set; }
    }
}
