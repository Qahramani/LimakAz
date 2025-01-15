using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.ViewComponents;

public class UserPanelViewComponent : ViewComponent
{
    private readonly IUserPanelService _userPanelService;

    public UserPanelViewComponent(IUserPanelService userPanelService)
    {
        _userPanelService = userPanelService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var dto = await _userPanelService.GetUserPanelInfoAsync();

        return View(dto);
    }
}
