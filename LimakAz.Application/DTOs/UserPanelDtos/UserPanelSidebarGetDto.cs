using Microsoft.AspNetCore.Mvc.Rendering;

namespace LimakAz.Application.DTOs;

public class UserPanelSidebarGetDto
{
    public string? Fullname { get; set; }
    public string? Code { get; set; }
}

public class UserProfileUpdateDto
{
    public string? Firstname { get; set; }
    public string? Lastname { get; set; } 
    public string? Address { get; set; }
    public DateTime BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
    public NumberPrefixType NumberPrefixType { get; set; }
    public int LocalPointId { get; set; }
    public List<SelectListItem> LocalPoints { get; set; } = [];
}

public class UserPasswordUpdateDto
{
    public string? Password { get; set; }
    public string? NewPassword { get; set; }
    public string? ConfirmPassword { get; set; }

}

public class UserSettingDto
{
    public UserProfileUpdateDto UserProfileInfo { get; set; } = new();
    public UserPasswordUpdateDto UserPasswordInfo { get; set; } = new();
}