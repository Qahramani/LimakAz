namespace LimakAz.Application.DTOs;

public class CertificateGetDto : IDto
{
    public int Id { get; set; }
    public string? Link { get; set; }
    public string? ImagePath { get; set; }
}
