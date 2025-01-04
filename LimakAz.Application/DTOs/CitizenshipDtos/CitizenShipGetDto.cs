namespace LimakAz.Application.DTOs;

public class CitizenShipGetDto : IDto
{
    public int Id { get; set; }
    public List<CitizenShipDetailGetDto> CitizenShipDetails { get; set; } = [];
}
