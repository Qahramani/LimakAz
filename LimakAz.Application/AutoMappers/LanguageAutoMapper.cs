using LimakAz.Application.DTOs.LanguageDtos;

namespace LimakAz.Application.AutoMappers;

internal class LanguageAutoMapper : Profile
{
    public LanguageAutoMapper()
    {
        CreateMap<Language, LanguageGetDto>().ReverseMap();
    }
}
