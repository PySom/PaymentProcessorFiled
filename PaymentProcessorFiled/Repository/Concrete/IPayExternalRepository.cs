
using PaymentProcessorFiled.Enums;

namespace PaymentProcessorFiled.Repository.Concrete
{
    public interface IPayExternalRepository
    {
        /// <summary>
        /// Begin transaction for the said amount
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>PayState</returns>
        public PayState InitiateTransaction(decimal amount);
    }
}
