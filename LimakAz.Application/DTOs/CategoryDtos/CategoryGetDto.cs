namespace LimakAz.Application.DTOs;

public class CategoryGetDto : IDto
{
    public int Id { get; set; }
    public string? LogoPath { get; set; }
    public List<CategoryDetailGetDto> CategoryDetails { get; set; } = [];
}
