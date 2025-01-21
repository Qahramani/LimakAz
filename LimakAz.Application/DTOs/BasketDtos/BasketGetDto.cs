namespace LimakAz.Application.DTOs;

public class BasketItemGetDto
{
    public bool IsSelected { get; set; } = true;
    public string? Link { get; set; }
    public decimal CargoPrice { get; set; }
    public decimal ItemPrice { get; set; }
    public int Count { get; set; }
    public decimal OrderTotalPrice { get; set; }
}


