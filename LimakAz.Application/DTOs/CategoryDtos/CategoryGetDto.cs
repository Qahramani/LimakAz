using Microsoft.AspNetCore.Http;

namespace LimakAz.Application.DTOs;

public class CategoryGetDto : IDto
{
    public int Id { get; set; }
    public string? LogoPath { get; set; }
    public List<CategoryDetailGetDto> CategoryDetails { get; set; } = [];
}


public class CategoryCreateDto : IDto
{
    public string? LogoPath { get; set; }
    public IFormFile? ImageFile { get; set; }
    public List<CategoryDetailCreateDto> CategoryDetails { get; set; } = [];
}

public class CategoryUpdateDto : IDto
{
    public int Id { get; set; }
    public IFormFile? ImageFile { get; set; }
    public List<CategoryDetailUpdateDto> CategoryDetails { get; set; } = [];

    }