namespace LimakAz.Application.DTOs;

public class UserSettingDto
{
    public UserProfileUpdateDto UserProfileInfo { get; set; } = new();
    public UserPasswordUpdateDto UserPasswordInfo { get; set; } = new();
}