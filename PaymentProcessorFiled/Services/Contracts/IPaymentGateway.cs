using PaymentProcessorFiled.Enums;

namespace PaymentProcessorFiled.Services.Contracts
{
    public interface IPaymentGateway
    {
        public PayState Process();
        public bool IsAvailable { get; }
    }
}
