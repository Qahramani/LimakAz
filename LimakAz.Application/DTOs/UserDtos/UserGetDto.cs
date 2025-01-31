namespace LimakAz.Application.DTOs;

public class UserGetDto
{
    public string Id { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<string> Roles { get; set; }
    public bool IsActive { get; set; }
    public int ChatId { get; set; }
}

