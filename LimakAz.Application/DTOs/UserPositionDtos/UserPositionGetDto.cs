namespace LimakAz.Application.DTOs;

public class UserPositionGetDto : IDto
{
    public int Id { get; set; }
    public List<UserPositionDetailGetDto> UserPositionDetails { get; set; } = [];
}
