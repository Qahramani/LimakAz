using Microsoft.AspNetCore.Http;

namespace LimakAz.Application.DTOs;

public class SliderUpdateDto : IDto
{
    public int Id { get; set; }
    public IFormFile? ImageFile { get; set  ; }
}
