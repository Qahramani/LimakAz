using Microsoft.AspNetCore.Http;

namespace LimakAz.Application.DTOs;

public class CountryCreateDto : IDto
{
    public string? ImagePath { get; set; }
    public IFormFile? ImageFile { get; set; }
    public List<CountryDetailCreateDto> CountryDetails { get; set; } = [];
}

