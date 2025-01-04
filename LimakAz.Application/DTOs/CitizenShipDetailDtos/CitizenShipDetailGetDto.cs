namespace LimakAz.Application.DTOs;

public class CitizenShipDetailGetDto :IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int LanguageId { get; set; }
}
