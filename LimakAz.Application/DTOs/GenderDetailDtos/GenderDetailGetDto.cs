namespace LimakAz.Application.DTOs;

public class GenderDetailGetDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int LanguageId { get; set; }
}
