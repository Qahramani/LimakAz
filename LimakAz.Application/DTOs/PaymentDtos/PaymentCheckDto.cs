namespace LimakAz.Application.DTOs;
public class PaymentCheckDto : IDto
{
    public string Token { get; set; } = null!;
    public int ID { get; set; }
    public PaymentStatuses STATUS { get; set; }
}

public class PaymentCreateDto : IDto
{
    public decimal Amount { get; set; }
    public string Description { get; set; } = null!;
}



public class PaymentResponseDto : IDto
{
    public OrderDto Order { get; set; } = null!;
}

public class OrderDto : IDto
{
    public int Id { get; set; }
    public string Password { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string HppUrl { get; set; } = null!;
    public string Cvv2AuthStatus { get; set; } = null!;
    public string Secret { get; set; } = null!;
}
