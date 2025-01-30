using Microsoft.AspNetCore.Http;

namespace LimakAz.Application.DTOs;

public class CertificateUpdateDto : IDto
{
    public int Id { get; set; }
    public string? Link { get; set; }
    public IFormFile? ImageFile { get; set; }
}
