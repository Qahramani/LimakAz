namespace LimakAz.Application.DTOs;

public class ContentUpdateDto : IDto
{
    public int Id { get; set; }
    public PageType? PageType { get; set; }
    public List<ContentDetailCreateDto> ContentDetails { get; set; } = [];
}