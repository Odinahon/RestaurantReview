using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class CheckFuture: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext){
            DateTime Today = DateTime.Now;
            if((DateTime)value> Today)
            {
                return new ValidationResult("Date of Visit can not be in the Future");
            }
            return ValidationResult.Success;
        }
    }
}