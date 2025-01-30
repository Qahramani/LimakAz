namespace LimakAz.Application.DTOs;

public class LocalPointGetDto : IDto
{
    public int Id { get; set; }
    public List<LocalPointDetailGetDto> LocalPointDetails { get; set; } = [];
}
