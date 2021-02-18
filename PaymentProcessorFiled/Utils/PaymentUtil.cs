using PaymentProcessorFiled.Enums;
using System;

namespace PaymentProcessorFiled.Utils
{
    public static class PaymentUtil
    {
        public static PayState GeneratePayState()
        {
            int value = new Random().Next(100);
            if (value > 50) return PayState.Processed;
            return PayState.Failed;
        }
    }
}
