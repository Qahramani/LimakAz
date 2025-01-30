using Microsoft.AspNetCore.Http;

namespace LimakAz.Application.DTOs;

public class SliderCreateDto : IDto
{
    public string? ImagePath { get; set; }
    public IFormFile? ImageFile { get; set; }
}
