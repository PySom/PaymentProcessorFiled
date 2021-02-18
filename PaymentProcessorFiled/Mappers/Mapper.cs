using AutoMapper;
using PaymentProcessorFiled.Domains;
using PaymentProcessorFiled.Domains.DTO;
using PaymentProcessorFiled.Domains.ViewModel;

namespace PaymentProcessorFiled.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            //payment mapping
            CreateMap<Payment, PaymentViewModel>()
                .ReverseMap();
            CreateMap<Payment, PaymentDTO>()
                .ForMember(dest => dest.PaymentState, opt => opt.MapFrom(d => $"{d.PaymentState.PayState}"))
                .ReverseMap();

        }
    }
}
