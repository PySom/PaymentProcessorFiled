using PaymentProcessorFiled.Data;
using PaymentProcessorFiled.Domains;
using PaymentProcessorFiled.Enums;
using PaymentProcessorFiled.Repository.Generics;
using System;
using System.Threading.Tasks;

namespace PaymentProcessorFiled.Repository.Concrete
{
    public class PaymentRepository : ModelManager<Payment>, IPaymentRepository
    {
        public PaymentRepository()
        { }
        public PaymentRepository(ApplicationDbContext context): base(context)
        {}

        public override ValueTask<Payment> AddAsync(Payment model)
        {
            model.PaymentState = new PaymentState { PayState = PayState.Pending, DateAdded = DateTime.Now };
            return base.AddAsync(model);
        }
    }
}
