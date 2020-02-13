using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Terminarz.Validators
{
    public class FutureDate : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && (DateTime)value > DateTime.Now;
        }
    }
}
