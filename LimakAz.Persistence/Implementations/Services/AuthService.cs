using LimakAz.Application.Interfaces.Helpers;
using LimakAz.Application.Interfaces.Services.External;
using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;

namespace LimakAz.Persistence.Implementations.Services;

internal class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
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

    public AuthService(ILocalPointService localPointService, IGenderService genderService, ICitizenShipService cityShipService, IUserPositionService userPositionService, IMapper mapper, IEmailService emailService, IUrlHelper urlHelper, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager, IValidationMessageProvider localizer)
    {
        _localPointService = localPointService;
        _genderService = genderService;
        _cityShipService = cityShipService;
        _userPositionService = userPositionService;
        _mapper = mapper;
        _emailService = emailService;
        _urlHelper = urlHelper;
        _contextAccessor = contextAccessor;
        _userManager = userManager;
        _localizer = localizer;
        _staticFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Connex.Business", "StaticFiles");
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

        var result = await _userManager.CreateAsync(user, dto.Password!);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", string.Join(",", result.Errors.Select(x => x.Description)));
            return false;
        }

        await _userManager.AddToRoleAsync(user, RoleType.Member.ToString());

        await _sendConfirmEmailToken(user);

        return true;
    }





    private async Task _sendConfirmEmailToken(AppUser user)
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


        string emailBody = await _getTemplateContentAsync(link ?? "", user.UserName ?? "", "ConfirmEmailBody.html");


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

        using StreamReader streamReader = new StreamReader(path);
        string result = await streamReader.ReadToEndAsync();

        result = result.Replace("[REPLACE_URL]", url);
        result = result.Replace("[REPLACE_USERNAME]", username);

        streamReader.Close();
        return result;
    }
}
