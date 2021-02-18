using PaymentProcessorFiled.Enums;
using PaymentProcessorFiled.Services.Contracts;
using PaymentProcessorFiled.Utils;
using System;

namespace PaymentProcessorFiled.Services.MockPayments
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        public bool IsAvailable => new Random().Next(2) > 0;

        public PayState Process()
        {
            return PaymentUtil.GeneratePayState();
        }
    }
}
