using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaymentProcessorFiled.Domains;
using PaymentProcessorFiled.Domains.DTO;
using PaymentProcessorFiled.Domains.ViewModel;
using PaymentProcessorFiled.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessorFiled.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public PaymentsController(IUnitOfWork uow, IMapper mapper) => (_uow, _mapper) = (uow, mapper);
        [HttpPost]
        public async ValueTask<ActionResult<PaymentDTO>> ProcessPayment([FromBody] PaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Payment data = await _uow.PaymentRepository.AddAsync(_mapper.Map<PaymentViewModel, Payment>(model));
                await _uow.SaveChangesAsync();
                PaymentState updatedPaymentState = data.PaymentState;
                updatedPaymentState.PayState = _uow.PayExternalRepository.InitiateTransaction(data.Amount); ;
                _uow.PaymentStateRepository.Update(updatedPaymentState);
                await _uow.SaveChangesAsync();
                return Ok(_mapper.Map<Payment, PaymentDTO>(data));
            }
            return BadRequest(new { Errors = ModelState.Values.SelectMany(e => e.Errors).ToList() });
        }
    }
}
