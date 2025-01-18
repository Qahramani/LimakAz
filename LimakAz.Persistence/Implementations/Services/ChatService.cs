using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LimakAz.Persistence.Implementations.Services;

internal class ChatService : IChatService
{
    private readonly IChatRepository _chatRepository;
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;
    public ChatService(IChatRepository chatRepository, IMapper mapper, IAuthService authService)
    {
        _chatRepository = chatRepository;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<bool> CreateAsync(ChatCreateDto dto, ModelStateDictionary ModelState)
    {
        var user = _authService.GetAutrhorizedUser();

        return true;
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public List<ChatGetDto> GetAll(LanguageType language = LanguageType.Azerbaijan)
    {
        throw new NotImplementedException();
    }

    public Task<ChatGetDto> GetAsync(int id, LanguageType language = LanguageType.Azerbaijan)
    {
        throw new NotImplementedException();
    }

    public Task<PaginateDto<ChatGetDto>> GetPagesAsync(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10)
    {
        throw new NotImplementedException();
    }

    public Task<ChatUpdateDto> GetUpdatedDtoAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsExistAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(ChatUpdateDto dto, ModelStateDictionary ModelState)
    {
        throw new NotImplementedException();
    }
}


