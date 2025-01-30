namespace LimakAz.Application.DTOs;

public class LocalPointDetailUpdateDto : IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? WorkingHourse { get; set; }
    public int LanguageId { get; set; }
}



