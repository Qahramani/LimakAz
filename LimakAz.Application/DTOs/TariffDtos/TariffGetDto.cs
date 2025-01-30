namespace LimakAz.Application.DTOs;

public class TariffGetDto : IDto
{
    public int Id { get; set; }
    public decimal MinValue { get; set; }
    public decimal MaxValue { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
}

