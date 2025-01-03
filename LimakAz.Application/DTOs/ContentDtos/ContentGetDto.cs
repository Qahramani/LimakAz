using LimakAz.Domain.Entities.Common;

namespace LimakAz.Application.DTOs;

public class ContentGetDto : IDto
{
    public int Id { get; set; }
    public PageType PageType { get; set; }
    public DateTime CreatedAt { get; set; } 
    public List<ContentDetailGetDto> ContentDetails { get; set; } = [];
}

public class ContentCreateDto : IDto
{
    public PageType PageType { get; set; }
    public List<ContentDetailCreateDto> ContentDetails { get; set; } = [];
}

public class ContentUpdateDto : IDto
{
    public int Id { get; set; }
    public PageType PageType { get; set; }
    public List<ContentDetailCreateDto> ContentDetails { get; set; } = [];
}