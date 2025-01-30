using Microsoft.AspNetCore.Mvc.Rendering;

namespace LimakAz.Application.DTOs;

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
