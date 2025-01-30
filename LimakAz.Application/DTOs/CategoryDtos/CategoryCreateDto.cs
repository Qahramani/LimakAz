using Microsoft.AspNetCore.Http;

namespace LimakAz.Application.DTOs;

public class CategoryCreateDto : IDto
{
    public string? LogoPath { get; set; }
    public IFormFile? ImageFile { get; set; }
    public List<CategoryDetailCreateDto> CategoryDetails { get; set; } = [];
}
