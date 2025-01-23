namespace LimakAz.Application.DTOs;

public class PaymentConfigurationDto:IDto
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string BaseUrl { get; set; } = null!;
}
