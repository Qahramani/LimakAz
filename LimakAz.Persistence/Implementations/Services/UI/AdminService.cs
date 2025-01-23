using LimakAz.Application.Interfaces.Services.UI;
using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LimakAz.Persistence.Implementations.Services.UI;

internal class AdminService : IAdminService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IChatService _chatService;
    public AdminService(UserManager<AppUser> userManager, IChatService chatService)
    {
        _userManager = userManager;
        _chatService = chatService;
    }

    public async Task<List<UserGetDto>> GetUsersAsync()
    {
        var users = await _userManager.Users.ToListAsync();

        var userRoles = new List<UserGetDto>();

        var chats = _chatService.GetAll();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains(RoleType.Admin.ToString()) || roles.Contains(RoleType.Moderator.ToString()))
                continue;

            var chat = await _chatService.GetChatByUseIdAsync(user.Id);

            userRoles.Add(new UserGetDto
            {
                Id = user.Id,
                Fullname = user.Firstname + " " + user.Lastname,
                Email = user.Email!,
                Roles = roles.ToList(),
                IsActive = user.IsActive,
                ChatId = chat.Id
            });
        }

        return userRoles;
    }
    public async Task<bool> UpdateUserRolesAsync(string userId, List<string> newRoles)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null) return false;

        var currentRoles = await _userManager.GetRolesAsync(user);

        var rolesToRemove = currentRoles.Except(newRoles).ToList();

        if (rolesToRemove.Any())
        {
            var result = await _userManager.RemoveFromRolesAsync(user, rolesToRemove);

            if (!result.Succeeded) return false;
        }

        var rolesToAdd = newRoles.Except(currentRoles).ToList();
        if (rolesToAdd.Any())
        {
            var result = await _userManager.AddToRolesAsync(user, rolesToAdd);
            if (!result.Succeeded)
            {
                return false;
            }
        }

        return true;
    }

    public async Task<bool> ActivateUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null) return false;

        user.IsActive = true;
        var result = await _userManager.UpdateAsync(user);

        return result.Succeeded;
    }

    public async Task<bool> DeactivateUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return false;

        user.IsActive = false;
        var result = await _userManager.UpdateAsync(user);

        return result.Succeeded;
    }

}


