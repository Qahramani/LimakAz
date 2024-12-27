using Microsoft.AspNetCore.Http;

namespace LimakAz.Application.DTOs;

public class CountryGetDto : IDto
{
    public int Id { get; set; }
    public string? ImagePath { get; set; }
    public List<CountryDetailGetDto> CountryDetails { get; set; } = [];
   // public ICollection<Shop> Shops { get; set; } = [];
    public List<TariffGetDto> Tariffs { get; set; } = [];
}

public class CountryCreateDto : IDto
{
    public string? ImagePath { get; set; }
    public IFormFile ImageFile { get; set; } = null!;
    public List<CountryDetailCreateDto> CountryDetails { get; set; } = [];
    //public ICollection<Shop> Shops { get; set; } = [];
    //public ICollection<Tariff> Tariffs { get; set; } = [];
}

public class CountryUpdateDto : IDto
{
    public int Id { get; set; }
    public IFormFile? ImageFile { get; set; } 
    public List<CountryDetailUpdateDto> CountryDetails { get; set; } = [];
    //public ICollection<Shop> Shops { get; set; } = [];
    //public ICollection<Tariff> Tariffs { get; set; } = [];
}