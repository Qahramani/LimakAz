namespace LimakAz.Application.AutoMappers;

internal class MessageAutoMapper : Profile
{
    public MessageAutoMapper()
    {
        CreateMap<Message, MessageGetDto>().ReverseMap();
        CreateMap<Message, MessageCreateDto>().ReverseMap();
        CreateMap<Message, MessageUpdateDto>().ReverseMap();
        CreateMap<Message, MessageDisplayDto>()
            .ForMember(desc => desc.Fullname, opt => opt.MapFrom(src => src.User != null ? $"{src.User.Firstname} {src.User.Lastname}" : $"{src.ChatId}"))
            .ForMember(desc => desc.Text, opt => opt.MapFrom(x => x.Text))
            .ForMember(desc => desc.SendAt, opt => opt.MapFrom(x => x.CreatedAt))
            .ForMember(desc => desc.UserId,opt => opt.MapFrom(x => x.UserId))
            .ForMember(desc => desc.ChatId,opt => opt.MapFrom(x => x.ChatId))
            .ReverseMap();

    }
}
