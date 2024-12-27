namespace LimakAz.Application.DTOs;

public class CountryDetailGetDto : IDto
{
    public int Id { get; set; }
    public string? Name{ get; set; }
    public int LanguageId { get; set; }
}

public class CountryDetailCreateDto : IDto
{
    public string Name { get; set; } = null!;
    public int LanguageId { get; set; }
}
public class CountryDetailUpdateDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int LanguageId { get; set; }
}