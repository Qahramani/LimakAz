using Microsoft.AspNetCore.Http;

namespace LimakAz.Application.DTOs;

public class SliderGetDto : IDto
{
    public int Id { get; set; }
    public string? ImagePath { get; set; }
}
public class SliderCreateDto : IDto
{
    public string? ImagePath { get; set; }
    public IFormFile? ImageFile { get; set; }
}
public class SliderUpdateDto : IDto
{
    public int Id { get; set; }
    public IFormFile? ImageFile { get; set  ; }
}
