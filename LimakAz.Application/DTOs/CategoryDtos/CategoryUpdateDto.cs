using Microsoft.AspNetCore.Http;

namespace LimakAz.Application.DTOs;

public class CategoryUpdateDto : IDto
{
    public int Id { get; set; }
    public IFormFile? ImageFile { get; set; }
    public List<CategoryDetailUpdateDto> CategoryDetails { get; set; } = [];

}