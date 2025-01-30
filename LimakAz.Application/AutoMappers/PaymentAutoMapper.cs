namespace LimakAz.Application.AutoMappers;

public class PaymentAutoMapper : Profile
{
    public PaymentAutoMapper()
    {

        CreateMap<Payment, PaymentGetDto>().ReverseMap();
       
    }
}