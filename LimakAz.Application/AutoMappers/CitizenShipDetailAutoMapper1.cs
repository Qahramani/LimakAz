namespace LimakAz.Application.AutoMappers;

internal class CitizenShipDetailAutoMapper : Profile
{
    public CitizenShipDetailAutoMapper()
    {
        CreateMap<CitizenShipDetail, CitizenShipDetailGetDto>().ReverseMap();
    }
}
