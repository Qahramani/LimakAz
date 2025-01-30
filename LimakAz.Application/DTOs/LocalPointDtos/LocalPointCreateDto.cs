namespace LimakAz.Application.DTOs;

public class LocalPointCreateDto : IDto
{
    public List<LocalPointDetailCreateDto> LocalPointDetails { get; set; } = [];
}
