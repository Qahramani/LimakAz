using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace LimakAz.Domain.Entities;

public class AppUser : IdentityUser
{
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string FinCode { get; set; } = null!;
    public string SerialNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    //public bool IsActive { get; set; } = true;
    public decimal AZNBalance { get; set; } 
    public decimal TRYBalance { get; set; } 
    public NotificationType NotificationType { get; set; } 
    public DateTime BirthDate { get; set; }
    public int LocalPointId { get; set; }
    public LocalPoint? LocalPoint{ get; set; }
    public int GenderId { get; set; }
    public Gender? Gender { get; set; }
    public int CitizenShipId { get; set; }
    public CitizenShip? CitizenShip { get; set; }
    public int UserPositionId { get; set; }
    public UserPosition? UserPosition { get; set; }
}
