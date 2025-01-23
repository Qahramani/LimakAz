using LimakAz.Application.Interfaces.Helpers;
using LimakAz.Application.Interfaces.Services.External;
using LimakAz.Domain.Enums;
using LimakAz.Persistence.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;

namespace LimakAz.Persistence.Implementations.Services;

internal class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IUrlHelper _urlHelper;
    private readonly string _staticFilesPath;
    private readonly ILocalPointService _localPointService;
    private readonly IGenderService _genderService;
    private readonly ICitizenShipService _cityShipService;
    private readonly IUserPositionService _userPositionService;
    private readonly IValidationMessageProvider _localizer;
    private readonly ICookieService _cookieService;
    public AuthService(ILocalPointService localPointService, IGenderService genderService, ICitizenShipService cityShipService,
                       IUserPositionService userPositionService, IMapper mapper, IEmailService emailService, IHttpContextAccessor contextAccessor,
                       UserManager<AppUser> userManager, IValidationMessageProvider localizer, IUrlHelperFactory urlHelperFactory,
                       IActionContextAccessor actionContextAccessor, SignInManager<AppUser> signInManager, ICookieService cookieService)
    {
        _localPointService = localPointService;
        _genderService = genderService;
        _cityShipService = cityShipService;
        _userPositionService = userPositionService;
        _mapper = mapper;
        _emailService = emailService;
        _contextAccessor = contextAccessor;
        _userManager = userManager;
        _localizer = localizer;
        var root = Helper.GetSolutionRoot();
        _staticFilesPath = Path.Combine(root, "LimakAz.Infrastructure", "StaticFiles");

        _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext ?? new());
        _signInManager = signInManager;
        _cookieService = cookieService;
    }

    public RegisterDto GetRegisterDto(RegisterDto dto, LanguageType language = LanguageType.Azerbaijan)
    {
        var genders = _genderService.GetAllAsync(language);
        var userPositions = _userPositionService.GetAllAsync(language);
        var citizenShips = _cityShipService.GetAllAsync(language);
        var localPoints = _localPointService.GetAll(language);

        dto = new()
        {
            Genders = genders.Select(x => new SelectListItem
            {
                Text = x.GenderDetails.FirstOrDefault()?.Name,
                Value = x.Id.ToString()
            }).ToList(),
            UserPositions = userPositions.Select(x => new SelectListItem
            {
                Text = x.UserPositionDetails.FirstOrDefault()?.Name,
                Value = x.Id.ToString()
            }).ToList(),
            CitizenShips = citizenShips.Select(x => new SelectListItem
            {
                Text = x.CitizenShipDetails.FirstOrDefault()?.Name,
                Value = x.Id.ToString()
            }).ToList(),
            LocalPoints = localPoints.Select(x => new SelectListItem
            {
                Text = x.LocalPointDetails.FirstOrDefault()?.Name,
                Value = x.Id.ToString()
            }).ToList()
        };

        return dto;

    }

    public async Task<bool> RegisterAsync(RegisterDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        bool isValid = Enum.IsDefined(typeof(UserPositionType), dto.UserPositionId);

        if (!isValid)
        {
            ModelState.AddModelError("UserPositionId", _localizer.GetValue("Invalid_Input"));
            return false;
        }

        isValid = Enum.IsDefined(typeof(CitizenShipType), dto.CitizenShipId);

        if (!isValid)
        {
            ModelState.AddModelError("CitizenShipId", _localizer.GetValue("Invalid_Input"));
            return false;
        }

        isValid = Enum.IsDefined(typeof(GenderType), dto.GenderId);

        if (!isValid)
        {
            ModelState.AddModelError("GenderId", _localizer.GetValue("Invalid_Input"));
            return false;
        }
        isValid = Enum.IsDefined(typeof(NotificationType), dto.NotificationType);

        if (!isValid)
        {
            ModelState.AddModelError("NotificationType", _localizer.GetValue("Invalid_Input"));
            return false;
        }

        isValid = Enum.IsDefined(typeof(NumberPrefixType), dto.NumberPrefixType);

        if (!isValid)
        {
            ModelState.AddModelError("NumberPrefixType", _localizer.GetValue("Invalid_Input"));
            return false;
        }

        var isLocalPointValid = await _localPointService.IsExistAsync(dto.LocalPointId);

        if (!isLocalPointValid)
        {
            ModelState.AddModelError("LocalPointId", _localizer.GetValue("Invalid_Input"));
            return false;
        }

        var isEmailAlreadyExist = await _userManager.FindByEmailAsync(dto.Email!);

        if (isEmailAlreadyExist != null)
        {
            ModelState.AddModelError("", _localizer.GetValue("DuplicateEmail"));
            return false;
        }

        var user = _mapper.Map<AppUser>(dto);

        user.PhoneNumber = ((int)(dto.NumberPrefixType)).ToString() + dto.PhoneNumber;

        user.UserName = dto.Firstname + Guid.NewGuid().ToString().Substring(0, 5);

        user.Code = Helper.GenerateUserCode();

        var result = await _userManager.CreateAsync(user, dto.Password!);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", string.Join(",", result.Errors.Select(x => x.Description)));
            return false;
        }


        await _userManager.AddToRoleAsync(user, RoleType.Member.ToString());

        await _sendConfirmEmailTokenAsync(user);

        return true;
    }


    private async Task _sendConfirmEmailTokenAsync(AppUser user)
    {
        string confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

        UrlActionContext context = new()
        {
            Action = "VerifyEmail",
            Controller = "Account",
            Values = new { token = confirmEmailToken, email = user.Email },
            Protocol = _contextAccessor.HttpContext?.Request.Scheme
        };

        var link = _urlHelper.Action(context);


        string emailBody = await _getTemplateContentAsync(link ?? "", user.Firstname ?? "", "ConfirmEmailBody.html");


        EmailSendDto emailSendDto = new()
        {
            Body = emailBody,
            Subject = "Email Təsdiqləmə",
            ToEmail = user.Email ?? "undifined@undifined.com"
        };

        await _emailService.SendEmailAsync(emailSendDto);
    }

    private async Task<string> _getTemplateContentAsync(string url, string username, string filename)
    {
        string path = Path.Combine(_staticFilesPath, filename);

        if (!File.Exists(path))
            throw new FileNotFoundException("Bele bir Template tapilmadi");

        string templateContent;
        using (var reader = new StreamReader(path))
        {
            templateContent = await reader.ReadToEndAsync();
        }

        templateContent = templateContent.Replace("{{UserName}}", username).Replace("{{Url}}", url);

        return templateContent;
    }

    public async Task<bool> LoginAsync(LoginDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var user = await _userManager.FindByEmailAsync(dto.Email!);

        if (user == null)
        {
            ModelState.AddModelError("", _localizer.GetValue("InvalidCredentials"));
            return false;
        }

        if (user.EmailConfirmed == false)
        {
            ModelState.AddModelError("", _localizer.GetValue("UnconfirmedEmail"));
            await _sendConfirmEmailTokenAsync(user);
            return false;
        }

        if (!user.IsActive)
        {
            ModelState.AddModelError("", _localizer.GetValue("BlockedUser"));
            return false;
        }

        var result = await _signInManager.PasswordSignInAsync(user, dto.Password!, dto.RememberMe, true);

        if (!result.Succeeded)
        {
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", _localizer.GetValue("BlockedUser"));
                return false;
            }
            ModelState.AddModelError("", _localizer.GetValue("InvalidCredentials"));
            return false;
        }

        //var roles = await _userManager.GetRolesAsync(user);

        //if(roles.Contains(RoleType.Admin.ToString()) || roles.Contains(RoleType.Moderator.ToString())) 
        //    return "/Admin/Dashboard/Index";

        return true;
    }

    public async Task<bool> ResetPasswordConfirmationAsync(ForgotPasswordDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var user = await _userManager.FindByEmailAsync(dto.Email);

        if (user == null)
            return false;

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        UrlActionContext context = new()
        {
            Action = "ResetPassword",
            Controller = "Account",
            Values = new { token, email = user.Email },
            Protocol = _contextAccessor.HttpContext?.Request.Scheme
        };

        var link = _urlHelper.Action(context);


        string emailBody = await _getTemplateContentAsync(link ?? "", user.Firstname ?? "", "ConfirmEmailBody.html");


        EmailSendDto emailSendDto = new()
        {
            Body = emailBody,
            Subject = "Email Təsdiqləmə",
            ToEmail = user.Email ?? "undifined@undifined.com"
        };

        await _emailService.SendEmailAsync(emailSendDto);

        return true;
    }

    public async Task<bool> ResetPasswordAsync(ResetPasswordDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        if(string.IsNullOrEmpty(dto.Email))
        {
            ModelState.AddModelError("", _localizer.GetValue("InvalidToken"));
            return false;
        }

        var user = await _userManager.FindByEmailAsync(dto.Email!);

        if (user == null)
        {
            ModelState.AddModelError("", _localizer.GetValue("InvalidEmail"));
            return false;
        }

        var result = await _userManager.ResetPasswordAsync(user, dto.Token!, dto.NewPassword!);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", string.Join(",", result.Errors.Select(x => x.Description)));
            return false;
        }

        return true;
    }

    public async Task<bool> LogoutAsync()
    {
        if (!_contextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false)
            return false;

        await _signInManager.SignOutAsync();

        return true;
    }

    public async Task<bool> EmailVerificationAsync(string token, string email)
    {
        if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(email))
            return false;

        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
            return false;

        var result = await _userManager.ConfirmEmailAsync(user, token);

        if (!result.Succeeded)
            return false;

        return true;
    }

    public async Task<AppUser> GetAuthenticatedUserAsync()
    {
        var userId =  _cookieService.GetUserId();

        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            throw new UnAuthorizedException();

        return user!;
    }

    public async Task<List<AppUser>> GetAllMembersAsync()
    {
        var users = await _userManager.GetUsersInRoleAsync(RoleType.Member.ToString());

        return users.ToList();
    }

    public async Task<List<string>> GetUserRolesAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            throw new NotFoundException("User tapilmadi");

        var roles = await _userManager.GetRolesAsync(user);

        return roles.ToList();
    }
}
