using Microsoft.AspNetCore.Http;

namespace LimakAz.Application.DTOs;

public class NewsCreateDto : IDto
{
    public string? ImagePath { get; set; }
    public IFormFile? ImageFile { get; set; }
    public List<NewsDetailCreateDto> NewsDetails { get; set; } = [];
}
