namespace LimakAz.Application.DTOs;

public class CountryDetailGetDto : IDto
{
    public int Id { get; set; }
    public string? Name{ get; set; }
    public int LanguageId { get; set; }
}
