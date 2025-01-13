using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LimakAz.Application.DTOs;

public class RegisterDto
{
    public string? Firstname { get; set; }
    public string? Lastname { get; set; } 
    public string? Email { get; set; } 
    public string? PhoneNumber { get; set; } 
    public string? Password { get; set; } 
    public string? ConfirmPassword { get; set; } 
    public string? FinCode { get; set; }
    public string? SerialNumber { get; set; }
    public string? Address { get; set; } 
    public bool IsActive { get; set; } = true;
    public decimal AZNBalance { get; set; }
    public decimal TRYBalance { get; set; }
    public bool IsTermsAccepted { get; set; } = true;
    public NotificationType NotificationType { get; set; }
    public NumberPrefixType NumberPrefixType { get; set; }
    public DateTime BirthDate { get; set; }
    public int LocalPointId { get; set; }
    public List<SelectListItem> LocalPoints { get; set; } = [];
    public int GenderId { get; set; }
    public List<SelectListItem> Genders { get; set; } = [];
    public int CitizenShipId { get; set; }
    public List<SelectListItem> CitizenShips { get; set; } = [];
    public int UserPositionId { get; set; }
    public List<SelectListItem> UserPositions { get; set; } = [];
}
