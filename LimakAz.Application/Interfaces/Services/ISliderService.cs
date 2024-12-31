using LimakAz.Application.Interfaces.Services.Generic;

namespace LimakAz.Application.Interfaces.Services;

public interface ISliderService : IGetService<SliderGetDto>, IModifyService<SliderCreateDto, SliderUpdateDto>
{
}