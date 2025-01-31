namespace LimakAz.Application.DTOs;

public class NotificationEmailDto
{
    public string Fullname { get; set; } = null!;
    public string NO { get; set; } = null!;
    public string CargoPrice { get; set; } = null!;
    public string LocalPointName { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}