using PaymentProcessorFiled.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentProcessorFiled.Validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class SecurityCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult result = ValidationResult.Success;
            string[] memberNames = new string[] { validationContext.MemberName };
            if (ValidationUtil.SecurityCodeIsNotValid(value))
            {
                return new ValidationResult("Only digits are allowed", memberNames);
            }
            return result;
        }
    }
}
