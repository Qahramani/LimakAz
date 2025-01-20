using LimakAz.Application.DTOs;

namespace LimakAz.Application.DTOs;

public class StatusDetailGetDto : IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int LanguageId { get; set; }
}

public class StatusDetailCreateDto : IDto
{
    public string? Name { get; set; }
    public int LanguageId { get; set; }
}


public class StatusDetailUpdateDto : IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int LanguageId { get; set; }
}
