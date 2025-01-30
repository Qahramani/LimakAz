namespace LimakAz.Application.DTOs;

public class ContentCreateDto : IDto
{
    public PageType? PageType { get; set; }
    public List<ContentDetailCreateDto> ContentDetails { get; set; } = [];
}
