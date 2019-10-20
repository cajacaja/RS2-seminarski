using Aplikacijaa.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacijaa.Helper
{
    public class AgeAttribute: ValidationAttribute
    {
    
          

            protected override ValidationResult IsValid(
                object value, ValidationContext validationContext)
            {
            var BirthDay = (AddingLandLordVM)validationContext.ObjectInstance;


            var Today = DateTime.Today;
            var dob = Today.Year - BirthDay.DateOfBirth.Year;

            if (BirthDay.DateOfBirth > Today.AddYears(-dob)) dob--;

            if (dob < 18)
            {
                return new ValidationResult(GetErrorMessage());
            }
           
            return ValidationResult.Success;
            }

           

            public string GetErrorMessage()
            {
                return $"Korisnik mora da bude stariji od 18 godina";
            }
        
    }
}
