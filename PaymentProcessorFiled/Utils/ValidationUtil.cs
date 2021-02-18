using CreditCardValidator;
using System;

namespace PaymentProcessorFiled.Utils
{
    public static class ValidationUtil
    {
        public static bool CardNumberIsValid(object value)
        {
            return Luhn.CheckLuhn((string)value);
        }

        public static bool CardHasExpired(object value)
        {
            DateTime date = (DateTime)value;
            return DateTime.Now >= date;
            
        }

        public static bool AmountIsNegative(decimal value)
        {
            return value < 0;

        }

        public static bool AmountIsZero(decimal value)
        {
            return value == 0;

        }

        public static bool SecurityCodeIsNotValid(object value)
        {
            return value is object && !int.TryParse((string)value, out _);
        }
    }
}
