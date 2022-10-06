using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_crude_mvc.Utils
{
    public class SetCorrectTypePrice: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value.GetType() != typeof(string) || value is null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Il valore inserito non è un numero");


        }
    }
}
