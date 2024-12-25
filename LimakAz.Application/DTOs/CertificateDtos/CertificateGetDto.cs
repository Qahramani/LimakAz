using Microsoft.AspNetCore.Http;

namespace LimakAz.Application.DTOs;

public class CertificateGetDto : IDto
{
    public int Id { get; set; }
    public string? Link { get; set; }
    public string? ImagePath { get; set; }
}

public class CertificateCreateDto : IDto
{
    public string Link { get; set; } = null!;
    public string? ImagePath { get; set; }
    public IFormFile ImageFile { get; set; } = null!;
}
public class CertificateUpdateDto : IDto
{
    public int Id { get; set; }
    public string Link { get; set; } = null!;
    public string? ImagePath { get; set; }
    public IFormFile? ImageFile { get; set; }
}
