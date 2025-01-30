namespace LimakAz.Application.DTOs;

public class StatusGetDto : IDto
{
    public int Id { get; set; }
    public List<StatusDetailGetDto> StatusDetails { get; set; } = [];
}
