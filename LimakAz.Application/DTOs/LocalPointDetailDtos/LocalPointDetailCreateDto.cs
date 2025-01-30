namespace LimakAz.Application.DTOs;

public class LocalPointDetailCreateDto : IDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? WorkingHourse { get; set; }
    public int LanguageId { get; set; }
}



