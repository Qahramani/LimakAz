using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LimakAz.Application.Interfaces.Services;

public interface IUserPanelService
{
    Task<UserPanelSidebarGetDto> GetUserPanelInfoAsync();
    Task<UserSettingDto> GetUserUpdateDtoAsync(LanguageType language = LanguageType.Azerbaijan);
    Task<bool> UpdatePasswordAsync(UserPasswordUpdateDto dto, ModelStateDictionary ModelState);
    Task<bool> UpdateProfileAsync(UserProfileUpdateDto dto, ModelStateDictionary ModelState);
}