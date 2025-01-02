using LimakAz.Application.Interfaces.Services.Generic;

namespace LimakAz.Application.Interfaces.Services;

public interface ILocalPointService : IGetService<LocalPointGetDto>,IModifyService<LocalPointCreateDto,LocalPointUpdateDto>
{
}
