namespace LimakAz.Application.DTOs;

public class StatusUpdateDto : IDto
{
    public int Id { get; set; }
    public List<StatusDetailUpdateDto> StatusDetails { get; set; } = [];
}