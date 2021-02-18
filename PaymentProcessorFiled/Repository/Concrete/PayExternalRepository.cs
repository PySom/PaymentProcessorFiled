using PaymentProcessorFiled.Enums;
using PaymentProcessorFiled.Services.Contracts;

namespace PaymentProcessorFiled.Repository.Concrete
{
    public class PayExternalRepository : IPayExternalRepository
    {
        private readonly ICheapPaymentGateway _cheapGateway;
        private readonly IExpensivePaymentGateway _expensiveGateway;
        private readonly IPremiumPaymentService _premiumService;
        public PayExternalRepository(ICheapPaymentGateway cheapGateway, 
            IExpensivePaymentGateway expensiveGateway,
            IPremiumPaymentService premiumService)
        {
            _cheapGateway = cheapGateway;
            _expensiveGateway = expensiveGateway;
            _premiumService = premiumService;
        }

        public PayState InitiateTransaction(decimal amount) 
        {
            if(amount < 20)
            {
                return _cheapGateway.Process();
            }
            else if(amount > 20 && amount <= 500)
            {
                if (_expensiveGateway.IsAvailable)
                {
                    return _expensiveGateway.Process();
                }
                else
                {
                    return _cheapGateway.Process();
                }
            }
            else
            {
                int retries = 0;
                PayState state = PayState.Pending;
                while(retries < 3 && state != PayState.Processed)
                {
                    state = _premiumService.Process();
                    retries += 1;
                }
                return state;
            }
        }
    }
}
