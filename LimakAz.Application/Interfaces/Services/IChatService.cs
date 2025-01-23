using LimakAz.Application.Interfaces.Services.Generic;

namespace LimakAz.Application.Interfaces.Services;

public interface IChatService : IGetService<ChatGetDto>, IModifyService<ChatCreateDto, ChatUpdateDto>
{
    Task<ChatGetDto> GetChatOfAuthenticatedUserAsync();
    //Task<List<ChatGetDto>> GetAllMembersAsync();
    Task<ChatGetDto> GetChatByUseIdAsync(string userId);
}
