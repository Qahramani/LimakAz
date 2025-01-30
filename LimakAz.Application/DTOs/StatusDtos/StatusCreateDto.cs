namespace LimakAz.Application.DTOs;

public class StatusCreateDto : IDto
{
    public List<StatusDetailCreateDto> StatusDetails { get; set; } = [];
}
