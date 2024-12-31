namespace LimakAz.Application.AutoMappers;

internal class SliderAutoMapper : Profile
{
    public SliderAutoMapper()
    {
        CreateMap<Slider,SliderGetDto>().ReverseMap();
        CreateMap<Slider,SliderCreateDto>().ReverseMap();
        CreateMap<Slider,SliderUpdateDto>().ReverseMap();
    }
}
