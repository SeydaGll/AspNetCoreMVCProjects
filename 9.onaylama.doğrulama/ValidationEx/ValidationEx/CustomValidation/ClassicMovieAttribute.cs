using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ValidationEx.ViewModels;

namespace ValidationEx.CustomValidation
{
    public class ClassicMovieAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Movie movie = (Movie)validationContext.ObjectInstance;
            if (movie.Price<10)
            {
                return new ValidationResult("Price Alanı 10 dan küçük olamaz");
            }

            return ValidationResult.Success;  
        }



        
    }
}
