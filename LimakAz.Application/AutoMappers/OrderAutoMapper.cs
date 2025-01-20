namespace LimakAz.Application.AutoMappers;

internal class OrderAutoMapper : Profile
{
    public OrderAutoMapper()
    {
        CreateMap<Order, OrderGetDto>().ReverseMap();
        CreateMap<Order, OrderUpdateDto>().ReverseMap();
        CreateMap<Order, OrderCreateDto>().ReverseMap();
    }
}

