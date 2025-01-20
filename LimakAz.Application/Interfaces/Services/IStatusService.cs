using LimakAz.Application.Interfaces.Services.Generic;


namespace LimakAz.Application.Interfaces.Services;

public interface IStatusService : IGetService<StatusGetDto>, IModifyService<StatusCreateDto, StatusUpdateDto>
{
}