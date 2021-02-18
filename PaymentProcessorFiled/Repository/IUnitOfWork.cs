using PaymentProcessorFiled.Domains;
using PaymentProcessorFiled.Repository.Concrete;
using PaymentProcessorFiled.Repository.Generics;
using System.Threading.Tasks;

namespace PaymentProcessorFiled.Repository
{
    public interface IUnitOfWork
    {
        public IPaymentRepository PaymentRepository { get; set; }
        public IModelManager<PaymentState> PaymentStateRepository { get; set; }
        public IPayExternalRepository PayExternalRepository { get; set; }

        public ValueTask SaveChangesAsync();
    }
}
