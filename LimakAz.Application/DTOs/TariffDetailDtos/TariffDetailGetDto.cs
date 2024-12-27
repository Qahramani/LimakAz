namespace LimakAz.Application.DTOs;

public class TariffDetailGetDto : IDto
{
    public int Id { get; set; }
    public string? Note { get; set; }
    public int LanguageId { get; set; }
}

public class TariffDetailCreateDto : IDto
{
    public string? Note { get; set; }
    public int LanguageId { get; set; }
}

public class TariffDetailUpdateDto : IDto
{
    public string? Note { get; set; }
    public int LanguageId { get; set; }
}