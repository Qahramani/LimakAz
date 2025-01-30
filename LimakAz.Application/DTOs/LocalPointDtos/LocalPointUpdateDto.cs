namespace LimakAz.Application.DTOs;

public class LocalPointUpdateDto : IDto
{
    public int Id { get; set; }
    public List<LocalPointDetailUpdateDto> LocalPointDetails { get; set; } = [];
}
