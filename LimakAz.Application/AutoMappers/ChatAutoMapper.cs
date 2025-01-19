namespace LimakAz.Application.AutoMappers;

internal class ChatAutoMapper : Profile
{
    public ChatAutoMapper()
    {
        CreateMap<Chat, ChatGetDto>().ReverseMap();
        CreateMap<Chat, ChatCreateDto>().ReverseMap();
        CreateMap<Chat, ChatUpdateDto>().ReverseMap();
    }
}
