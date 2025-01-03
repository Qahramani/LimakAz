namespace LimakAz.Application.DTOs;

public class ContentDetailGetDto : IDto
{
    public int Id { get; set; }
    public string? Key { get; set; }
    public string? Value { get; set; }
    public int ContentId { get; set; }
}

public class ContentDetailCreateDto : IDto
{
    public string? Key { get; set; }
    public string? Value { get; set; }
    public int LanguageId { get; set; }
}
public class ContentDetailUpdateDto : IDto
{
    public int Id { get; set; }
    public string? Key { get; set; }
    public string? Value { get; set; }
    public int LanguageId { get; set; }
}