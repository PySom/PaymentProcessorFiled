using CreditCardValidator;
using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentProcessorFiled.Validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class CreditCardWithLuhnAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult result = ValidationResult.Success;
            string[] memberNames = new string[] { validationContext.MemberName };
            if (!Luhn.CheckLuhn((string)value))
            {
                result = new ValidationResult("Please enter a valid credit card number", memberNames);
            }
            return result;
        }
    }
}
