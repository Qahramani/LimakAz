namespace LimakAz.Application.DTOs;

public class LocalPointDetailGetDto : IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? WorkingHourse { get; set; } 
    public int LocalPointId { get; set; }
    public LocalPoint? LocalPoint { get; set; }
    public int LanguageId { get; set; }
}
public class LocalPointDetailCreateDto : IDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? WorkingHourse { get; set; }
    public int LanguageId { get; set; }
}

public class LocalPointDetailUpdateDto : IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? WorkingHourse { get; set; }
    public int LanguageId { get; set; }
}



