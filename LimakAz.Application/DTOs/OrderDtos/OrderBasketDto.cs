namespace LimakAz.Application.DTOs;

public class OrderBasketDto
{
    public int SelectedLLocalPointId { get; set; }
    public int LocalPointId { get; set; }
    public List<LocalPointGetDto> LocalPoints { get; set; } = [];
    public int SelectedCountryId { get; set; } 
    public List<int> SelectedOrderIds { get; set; } = [];
    public List<OrderItemGetDto> Orders { get; set; } = [];
}
