namespace LimakAz.Application.Interfaces.Services.UI;

public interface IAdminService
{
    Task<List<UserWithRolesViewModel>> GetUsersAsync();
    Task<bool> UpdateUserRolesAsync(string userId, List<string> newRoles);
    Task<bool> ActivateUserAsync(string userId);
    Task<bool> DeactivateUserAsync(string userId);
}
