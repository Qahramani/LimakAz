using Microsoft.AspNetCore.Http;

namespace LimakAz.Application.DTOs;

public class NewsUpdateDto : IDto
{
    public int Id { get; set; }
    public IFormFile? ImageFile { get; set; }
    public List<NewsDetailUpdateDto> NewsDetails { get; set; } = [];
}