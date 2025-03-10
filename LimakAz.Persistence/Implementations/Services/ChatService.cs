﻿using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Data;

namespace LimakAz.Persistence.Implementations.Services;

internal class ChatService : IChatService
{
    private readonly IChatRepository _repository;
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;
    private readonly ICookieService _cookieService;
    private readonly UserManager<AppUser> _userManager;
    public ChatService(IChatRepository chatRepository, IMapper mapper, IAuthService authService, ICookieService cookieService, UserManager<AppUser> userManager)
    {
        _repository = chatRepository;
        _mapper = mapper;
        _authService = authService;
        _cookieService = cookieService;
        _userManager = userManager;
    }

    public async Task<bool> CreateAsync(ChatCreateDto dto, ModelStateDictionary ModelState)
    {
        var user = await _userManager.FindByIdAsync(dto.UserId);

        if (user == null)
            throw new NotFoundException();

        var roles = await _authService.GetUserRolesAsync(user.Id);

        if (roles.Contains(RoleType.Admin.ToString()) || roles.Contains(RoleType.Moderator.ToString()))
            return true;

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

    public async Task<bool> IsExistAsync(int id)
    {
        return await _repository.IsExistAsync(x => x.Id == id);
    }


  
    public async Task<ChatGetDto> GetChatOfAuthenticatedUserAsync()
    {
        var user = await _authService.GetAuthenticatedUserAsync();

        var chat = await _repository.GetAsync(x => x.UserId == user.Id, include: _getWithIncludes());

        if(chat == null)
        {
            var roles = await _authService.GetUserRolesAsync(user.Id);

            if (roles.Contains(RoleType.Admin.ToString()) || roles.Contains(RoleType.Moderator.ToString()))
                throw new InvalidUserRoleException();

            Chat newChat = new() { UserId  = user.Id };

            await _repository.CreateAsync(newChat);
            await _repository.SaveChangesAsync();

            chat = newChat;
        }

        var dto = _mapper.Map<ChatGetDto>(chat);

        return dto;
    }
    private static Func<IQueryable<Chat>, IIncludableQueryable<Chat, object>> _getWithIncludes()
    {
        return x => x.Include(x => x.User).Include(x => x.Moderator).Include(x => x.Messages);
    }

    public async Task<ChatGetDto> GetChatByUseIdAsync(string userId)
    {
        var chat = await _repository.GetAsync(x => x.UserId == userId, include: _getWithIncludes());

        if(chat == null)
        {
            var roles = await _authService.GetUserRolesAsync(userId);

            if (roles.Contains(RoleType.Admin.ToString()) || roles.Contains(RoleType.Moderator.ToString()))
                throw new InvalidUserRoleException();

            Chat newChat = new()
            {
                UserId = userId,
            };

            await _repository.CreateAsync(newChat);
            await _repository.SaveChangesAsync();

            chat = newChat;
        }

        var dto = _mapper.Map<ChatGetDto>(chat);
        return dto;
    }

    public async Task<bool> UpdateAsync(ChatUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;
        var chat = await _repository.GetAsync(x => x.Id == dto.Id, include: _getWithIncludes());

        if (chat == null) throw new NotFoundException();

        chat = _mapper.Map(dto, chat);

        _repository.Update(chat);
        await _repository.SaveChangesAsync();

        return true;
    }

    public Task<ChatUpdateDto> GetUpdatedDtoAsync(int id)
    {
        throw new NotImplementedException();
    }

}


