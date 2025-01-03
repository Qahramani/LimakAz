namespace LimakAz.Application.DTOs.AuthDto;

public class RegisterDto
{
    public string? Firstname { get; set; }
    public string? Lastname { get; set; } 
    public string? FinCode { get; set; }
    public string? SerialNumber { get; set; }
    public string? Address { get; set; } 
    public bool IsActive { get; set; } = true;
    public decimal AZNBalance { get; set; }
    public decimal TRYBalance { get; set; }
    public bool IsTermsAccepted { get; set; } = false;
    public NotificationType NotificationType { get; set; }
    public DateTime BirthDate { get; set; }
    public int LocalPointId { get; set; }
    public LocalPoint? LocalPoint { get; set; }
    public int GenderId { get; set; }
    public Gender? Gender { get; set; }
    public int CitizenShipId { get; set; }
    public CitizenShip? CitizenShip { get; set; }
    public int UserPositionId { get; set; }
    public UserPosition? UserPosition { get; set; }
}
