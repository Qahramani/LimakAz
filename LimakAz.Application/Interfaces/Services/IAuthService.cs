using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LimakAz.Application.Interfaces.Services;

public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterDto dto, ModelStateDictionary ModelState);
    RegisterDto GetRegisterDto(RegisterDto dto, LanguageType language = LanguageType.Azerbaijan);
    Task<bool> LoginAsync(LoginDto dto, ModelStateDictionary ModelState);
    Task<bool> ResetPasswordConfirmationAsync(ForgotPasswordDto dto, ModelStateDictionary ModelState);
    Task<bool> ResetPasswordAsync(ResetPasswordDto dto, ModelStateDictionary ModelState);
    Task<bool> LogoutAsync();
    Task<bool> EmailVerificationAsync(string token, string email);
    Task<AppUser> GetAuthenticatedUserAsync();
    Task<List<string>> GetUserRolesAsync(string userId);
    Task<List<AppUser>> GetAllMembersAsync();
    Task<string> GetRedirectUrlAsync(string email);
}
