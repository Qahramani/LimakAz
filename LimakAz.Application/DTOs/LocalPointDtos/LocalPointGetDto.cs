namespace LimakAz.Application.DTOs;

public class LocalPointGetDto : IDto
{
    public int Id { get; set; }
    public List<LocalPointDetailGetDto> LocalPointDetails { get; set; } = [];
}

public class LocalPointCreateDto : IDto
{
    public List<LocalPointDetailCreateDto> LocalPointDetails { get; set; } = [];
}
public class LocalPointUpdateDto : IDto
{
    public int Id { get; set; }
    public List<LocalPointDetailUpdateDto> LocalPointDetails { get; set; } = [];
}
