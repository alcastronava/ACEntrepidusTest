using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACEntrepidusTest19.Validations
{
    public class NotAfterTodayAttribute : ValidationAttribute
    {
        public NotAfterTodayAttribute()
            : base("El campo {0} es inválido.")
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Date > DateTime.Now.Date)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }

            }
            return ValidationResult.Success;
        }

    }
}
