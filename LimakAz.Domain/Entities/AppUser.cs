using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace LimakAz.Domain.Entities;

public class AppUser : IdentityUser
{
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Code { get; set; } = null!;
    public NotificationType NotificationType { get; set; } 
    public string SerialNumber { get; set; } = null!;
    public DateTime BirthDate { get; set; } 
    public string Address { get; set; } = null!;
    public bool IsActive { get; set; } = true;
    public bool IsTermsAccepted { get; set; } = false;
    public int LocationId { get; set; }
    public Location? Location { get; set; }
    public int GenderId { get; set; }
    public Gender? Gender { get; set; }
}
