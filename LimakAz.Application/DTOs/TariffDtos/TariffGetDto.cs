namespace LimakAz.Application.DTOs;

public class TariffGetDto : IDto
{
    public int Id { get; set; }
    public decimal MinValue { get; set; }
    public decimal MaxValue { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<TariffDetailGetDto> TariffDetails { get; set; } = [];
}
public class TariffCreateDto : IDto
{
    public decimal MinValue { get; set; }
    public decimal MaxValue { get; set; }
    public decimal Price { get; set; }
    public int CountryId { get; set; } 
    public List<TariffDetailCreateDto> TariffDetails { get; set; } = [];
}

public class TariffUpdateDto : IDto
{
    public int Id { get; set; }
    public decimal MinValue { get; set; }
    public decimal MaxValue { get; set; }
    public decimal Price { get; set; }
    public int CountryId { get; set; }
    public List<TariffDetailUpdateDto> TariffDetails { get; set; } = [];
}

