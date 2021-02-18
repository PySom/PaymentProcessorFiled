using CreditCardValidator;
using PaymentProcessorFiled.Utils;
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
            try
            {
                if (!ValidationUtil.CardNumberIsValid(value))
                {
                    result = new ValidationResult("Please enter a valid credit card number", memberNames);
                }
            }
            catch(ArgumentException ex)
            {
                result = new ValidationResult(ex.Message, memberNames);
            }
            
            return result;
        }
    }
}
