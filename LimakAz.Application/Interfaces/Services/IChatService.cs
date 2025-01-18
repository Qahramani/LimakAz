using LimakAz.Application.Interfaces.Services.Generic;

namespace LimakAz.Application.Interfaces.Services;

public interface IChatService : IGetService<ChatGetDto>, IModifyService<ChatCreateDto, ChatUpdateDto>
{
}
