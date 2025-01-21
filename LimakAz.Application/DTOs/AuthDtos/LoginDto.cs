namespace LimakAz.Application.DTOs;

public class LoginDto
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    public bool RememberMe { get; set; } = false;
}
public class LoginReturnDto
{
    public bool ModelState { get; set; } = false;
    public string returnUrl { get; set; } 
}