using PaymentProcessorFiled.Domains;
using PaymentProcessorFiled.Repository.Generics;

namespace PaymentProcessorFiled.Repository.Concrete
{
    public interface IPaymentRepository : IModelManager<Payment>
    {
    }
}
