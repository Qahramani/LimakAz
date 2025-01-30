using Microsoft.AspNetCore.Http;

namespace LimakAz.Application.DTOs;

public class CountryUpdateDto : IDto
{
    public int Id { get; set; }
    public IFormFile? ImageFile { get; set; } 
    public List<CountryDetailUpdateDto> CountryDetails { get; set; } = [];
}

