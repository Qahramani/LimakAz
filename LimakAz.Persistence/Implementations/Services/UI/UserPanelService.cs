using LimakAz.Application.Interfaces.Helpers;
using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LimakAz.Persistence.Implementations.Services.UI;

public class UserPanelService : IUserPanelService
{
    private readonly ICookieService _cookieService;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly ILocalPointService _localPointService;
    private readonly IValidationMessageProvider _localizer;
    public UserPanelService(ICookieService cookieService, UserManager<AppUser> userManager, IMapper mapper, ILocalPointService localPointService, IValidationMessageProvider localizer)
    {
        _cookieService = cookieService;
        _userManager = userManager;
        _mapper = mapper;
        _localPointService = localPointService;
        _localizer = localizer;
    }

    public async Task<UserPanelSidebarGetDto> GetUserPanelInfoAsync()
    {
        if (!_cookieService.IsAuthorized())
            throw new UnAuthorizedException();

        var userId = _cookieService.GetUserId();

        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            throw new NotFoundException("Istifadeci tapilmadi");

        UserPanelSidebarGetDto dto = new()
        {
            Code = user.Code,
            Fullname = user.Firstname + " " + user.Lastname
        };

        return dto;
    }

    public async Task<UserProfileUpdateDto> GetUserProfileUpdateDtoAsync(LanguageType language = LanguageType.Azerbaijan)
    {
        var userId = _cookieService.GetUserId();

        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            throw new NotFoundException();

        var localPoints = _localPointService.GetAll(language);

        UserProfileUpdateDto userInfo = new()
        {
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            BirthDate = user.BirthDate,
            LocalPointId = user.LocalPointId,
            Address = user.Address,
            PhoneNumber = user.PhoneNumber?.Substring(2),
            LocalPoints = localPoints.Select(x => new SelectListItem
            {
                Text = x.LocalPointDetails.FirstOrDefault()?.Name,
                Value = x.Id.ToString()
            }).ToList()
        };
        

        return userInfo;
    }

    public async Task<UserSettingDto> GetUserUpdateDtoAsync(LanguageType language = LanguageType.Azerbaijan)
    {
        var userId = _cookieService.GetUserId();

        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            throw new NotFoundException();

        var localPoints = _localPointService.GetAll(language);

        UserProfileUpdateDto userInfo = new()
        {
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            BirthDate = user.BirthDate,
            LocalPointId = user.LocalPointId,
            Address = user.Address,
            PhoneNumber = user.PhoneNumber?.Substring(2),
            LocalPoints = localPoints.Select(x => new SelectListItem
            {
                Text = x.LocalPointDetails.FirstOrDefault()?.Name,
                Value = x.Id.ToString()
            }).ToList()
        };
        UserSettingDto dto = new()
        {
            UserProfileInfo = userInfo,
        };

        return dto;

    }

    public async Task<bool> UpdatePasswordAsync(UserPasswordUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var userId = _cookieService.GetUserId();

        var user = await _userManager.FindByIdAsync(userId);

        if(user == null) 
            throw new NotFoundException();

        var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, dto.Password!);

        if(!isPasswordCorrect)
        {
            ModelState.AddModelError("", _localizer.GetValue("PasswordMismatch"));
            return false;
        }

        var result = await _userManager.ChangePasswordAsync(user, dto.Password!,dto.NewPassword!);

        if(!result.Succeeded)
        {
            ModelState.AddModelError("", string.Join(",", result.Errors.Select(x => x.Description)));
            return false;
        }

        return true;
    }

    public async Task<bool> UpdateProfileAsync(UserProfileUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var userId = _cookieService.GetUserId();

        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            throw new NotFoundException();

        var isValid = await _localPointService.IsExistAsync(dto.LocalPointId);

        if (!isValid)
        {
            ModelState.AddModelError("LocalPointId", _localizer.GetValue("Invalid_Input"));
            return false;
        }

        isValid = Enum.IsDefined(typeof(NumberPrefixType), dto.NumberPrefixType);

        if (!isValid)
        {
            ModelState.AddModelError("NumberPrefixType", _localizer.GetValue("Invalid_Input"));
            return false;
        }

        user.Firstname = dto.Firstname!;
        user.Lastname = dto.Lastname!;
        user.Address = dto.Address!;
        user.PhoneNumber = ((int)dto.NumberPrefixType).ToString() + dto.PhoneNumber;
        user.BirthDate = dto.BirthDate;
        user.LocalPointId = dto.LocalPointId;

        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", string.Join(",", result.Errors.Select(x => x.Description)));
            return false;
        }

        return true;
    }
}
