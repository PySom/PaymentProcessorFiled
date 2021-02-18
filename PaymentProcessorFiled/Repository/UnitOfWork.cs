using Microsoft.EntityFrameworkCore;
using PaymentProcessorFiled.Data;
using PaymentProcessorFiled.Domains;
using PaymentProcessorFiled.Exceptions;
using PaymentProcessorFiled.Repository.Concrete;
using PaymentProcessorFiled.Repository.Generics;
using System;
using System.Threading.Tasks;

namespace PaymentProcessorFiled.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly ApplicationDbContext _ctx;

        public UnitOfWork(ApplicationDbContext ctx, 
            IPaymentRepository paymentRepo, 
            IPayExternalRepository payExternalRepository,
            IModelManager<PaymentState> paymentStateRepo)
        {
            _ctx = ctx;
            PaymentRepository = paymentRepo;
            PaymentStateRepository = paymentStateRepo;
            PayExternalRepository = payExternalRepository;
        }
        
        private bool disposed = false;

        public IPaymentRepository PaymentRepository { get; set; }
        public IModelManager<PaymentState> PaymentStateRepository { get; set; }
        public IPayExternalRepository PayExternalRepository { get; set; }

        public async ValueTask SaveChangesAsync()
        {
            string errorMessage;
            try
            {
                await _ctx.SaveChangesAsync();
                return;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                errorMessage = ex.Message;
            }
            catch (DbUpdateException ex)
            {
                errorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            throw new AppException(errorMessage);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _ctx.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
