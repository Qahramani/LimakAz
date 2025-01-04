namespace LimakAz.Application.AutoMappers;

internal class CitizenShipAutoMapper : Profile
{
    public CitizenShipAutoMapper()
    {
        CreateMap<CitizenShip, CitizenShipGetDto>().ReverseMap();
    }
}