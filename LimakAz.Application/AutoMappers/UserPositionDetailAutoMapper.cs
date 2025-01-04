namespace LimakAz.Application.AutoMappers;

internal class UserPositionDetailAutoMapper : Profile
{
    public UserPositionDetailAutoMapper()
    {
        CreateMap<UserPositionDetail, UserPositionDetailGetDto>().ReverseMap();
    }
}
