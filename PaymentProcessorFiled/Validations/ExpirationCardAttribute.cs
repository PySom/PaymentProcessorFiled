using System;
using System.ComponentModel.DataAnnotations;
namespace PaymentProcessorFiled.Validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class ExpirationDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult result = ValidationResult.Success;
            string[] memberNames = new string[] { validationContext.MemberName };
            DateTime date = (DateTime)value;
            if(DateTime.Now >= date)
            {
                return new ValidationResult("Your card is expired. Please use a valid card", memberNames);
            }
            return result;
        }
    }
}
