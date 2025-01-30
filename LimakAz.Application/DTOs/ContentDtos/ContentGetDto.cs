using LimakAz.Domain.Entities.Common;

namespace LimakAz.Application.DTOs;

public class ContentGetDto : IDto
{
    public int Id { get; set; }
    public PageType PageType { get; set; }
    public DateTime UpdatedAt { get; set; } 
    public List<ContentDetailGetDto> ContentDetails { get; set; } = [];
}
