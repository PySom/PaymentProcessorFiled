using PaymentProcessorFiled.Enums;
using PaymentProcessorFiled.Services.Contracts;
using PaymentProcessorFiled.Utils;

namespace PaymentProcessorFiled.Services.MockPayments
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {
        public bool IsAvailable => true;

        public PayState Process()
        {
            return PaymentUtil.GeneratePayState();
        }
    }
}
