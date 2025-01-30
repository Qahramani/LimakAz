using Microsoft.AspNetCore.Http;

namespace LimakAz.Application.DTOs;

public class CertificateCreateDto : IDto
{
    public string Link { get; set; } = null!;
    public string? ImagePath { get; set; }
    public IFormFile? ImageFile { get; set; } 
}
