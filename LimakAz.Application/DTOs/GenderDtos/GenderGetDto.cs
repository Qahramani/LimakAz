namespace LimakAz.Application.DTOs;

public class GenderGetDto : IDto
{
    public int Id { get; set; }
    public List<GenderDetailGetDto> GenderDetails { get; set; } = [];
}
