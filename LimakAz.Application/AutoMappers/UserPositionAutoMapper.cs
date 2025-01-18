namespace LimakAz.Application.AutoMappers;

internal class UserPositionAutoMapper : Profile
{
    public UserPositionAutoMapper()
    {
        CreateMap<UserPosition, UserPositionGetDto>().ReverseMap();
    }
}
