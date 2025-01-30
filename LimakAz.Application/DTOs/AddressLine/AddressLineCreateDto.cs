namespace LimakAz.Application.DTOs;

public class AddressLineCreateDto : IDto
{
    public string? Key { get; set; }
    public string? Value { get; set; }
    public int CountryId { get; set; }
}



