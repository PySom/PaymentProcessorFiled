using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentProcessorFiled.Validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class PaymentAmountAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult result = ValidationResult.Success;
            string[] memberNames = new string[] { validationContext.MemberName };
            decimal amount = (decimal)value;
            if (amount < 0)
            {
                return new ValidationResult("We do not support credit. Please pay a valid amount.", memberNames);
            }
            return result;
        }
    }
}
