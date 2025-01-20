namespace LimakAz.Application.DTOs;

public class StatusGetDto : IDto
{
    public int Id { get; set; }
    public List<StatusDetailGetDto> StatusDetails { get; set; } = [];
}

public class StatusCreateDto : IDto
{
    public List<StatusDetailCreateDto> StatusDetails { get; set; } = [];
}
public class StatusUpdateDto : IDto
{
    public int Id { get; set; }
    public List<StatusDetailUpdateDto> StatusDetails { get; set; } = [];
}