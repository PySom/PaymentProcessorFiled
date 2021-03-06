﻿using PaymentProcessorFiled.Utils;
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
            if (ValidationUtil.AmountIsNegative(amount))
            {
                return new ValidationResult("We do not support credit. Please pay a valid amount.", memberNames);
            }
            else if(ValidationUtil.AmountIsZero(amount))
            {
                return new ValidationResult("You need to make a payment with a higer value", memberNames);
            }
            return result;
        }
    }
}
