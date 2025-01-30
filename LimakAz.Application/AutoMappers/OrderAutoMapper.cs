namespace LimakAz.Application.AutoMappers;

internal class OrderAutoMapper : Profile
{
    public OrderAutoMapper()
    {
        CreateMap<OrderItem, OrderItemGetDto>().ReverseMap();
        CreateMap<OrderItem, OrderUpdateDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemCreateDto>().ReverseMap();
    }
}

