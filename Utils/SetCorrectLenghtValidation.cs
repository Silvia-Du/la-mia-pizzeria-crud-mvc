using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_crude_mvc.Utils
{
    public class SetCorrectLenghtValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string receivedValue = (string)value;
            //int count = receivedValue.Trim().Split(' ').Count();
            if (receivedValue.Trim().Split(' ').Count() < 5)
            {
                return new ValidationResult("Il campo descrizione deve contenere almeno 5 parole");
            }
            return ValidationResult.Success;
        }
    }
}

//Bonus Prevediamo una validazione in più : vogliamo che la descrizione della pizza contenga almeno 5 parole.
