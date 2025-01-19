using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace LimakAz.Persistence.Implementations.Services;

internal class ChatService : IChatService
{
    private readonly IChatRepository _repository;
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;
    private readonly ICookieService _cookieService;
    public ChatService(IChatRepository chatRepository, IMapper mapper, IAuthService authService, ICookieService cookieService)
    {
        _repository = chatRepository;
        _mapper = mapper;
        _authService = authService;
        _cookieService = cookieService;
    }

    public async Task<bool> CreateAsync(ChatCreateDto dto, ModelStateDictionary ModelState)
    {
        var user = await _authService.GetAuthenticatedUserAsync();

        Chat chat = new()
        {
            UserId = user.Id,
            IsActive = true
        };

        await _repository.CreateAsync(chat);
        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var chat = await _repository.GetAsync(id);

        if (chat == null)
            throw new Exception();

        _repository.SoftDelete(chat);
        await _repository.SaveChangesAsync();
    }

    public  List<ChatGetDto> GetAll(LanguageType language = LanguageType.Azerbaijan)
    {
        var chats = _repository.GetAll(include: _getWithIncludes());

        chats.OrderByDescending(x => x.CreatedAt);

        var dtos = _mapper.Map<List<ChatGetDto>>(chats);


        return dtos;
    }

    public async Task<ChatGetDto> GetAsync(int id, LanguageType language = LanguageType.Azerbaijan)
    {
        var chat = await _repository.GetAsync(x => x.Id == id , include: _getWithIncludes());

        var dto = _mapper.Map<ChatGetDto>(chat);

        return dto;
    }

    public async Task<PaginateDto<ChatGetDto>> GetPagesAsync(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10)
    {
        var query = _repository.GetAll(include :  _getWithIncludes());

        var count = query.Count();

        var pageCount = (int)Math.Ceiling((decimal)count/limit);

        if(page > pageCount)
            page = pageCount;

        if (page < 1)
            page = 1;

        query = _repository.Paginate(query, limit, page);

        query.OrderByDescending(x => x.CreatedAt);

        var chats = await query.ToListAsync();

        var dtos = _mapper.Map<List<ChatGetDto>>(chats);

        PaginateDto<ChatGetDto> dto = new()
        {
            Items = dtos,
            PageCount = pageCount,
            CurrentPage = page,
        };

        return dto;
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

  
    public async Task<ChatGetDto> GetChatOfAuthenticatedUserAsync()
    {
        var user = await _authService.GetAuthenticatedUserAsync();

        var chat = await _repository.GetAsync(x => x.UserId == user.Id, include: _getWithIncludes());

        var dto = _mapper.Map<ChatGetDto>(chat);

        return dto;
    }
    private static Func<IQueryable<Chat>, IIncludableQueryable<Chat, object>> _getWithIncludes()
    {
        return x => x.Include(x => x.User).Include(x => x.Moderator).Include(x => x.Messages);
    }

    public async Task<List<ChatGetDto>> GetAllMembersAsync()
    {
        var members = await _authService.GetAllMembersAsync();
        var memberIds = members.Select(x => x.Id).ToList();
            
        var chats = _repository.GetAll(x => memberIds.Contains(x.UserId),include: _getWithIncludes());

        chats.OrderByDescending(x => x.CreatedAt);

        var dtos = _mapper.Map<List<ChatGetDto>>(chats);

        return dtos;
    }
}


