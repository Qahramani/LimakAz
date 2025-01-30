namespace LimakAz.Application.DTOs;
public class PaymentCheckDto : IDto
{
    public string Token { get; set; } = null!;
    public int ID { get; set; }
    public PaymentStatuses STATUS { get; set; }
}

public class PaymentGetDto : IDto
{
    public int Id { get; set; }
    public int ReceptId { get; set; }
    public string SecretId { get; set; }
    public string? ConfirmToken { get; set; }
    public PaymentStatuses PaymentStatus { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public List<OrderItemGetDto> Orders { get; set; } = [];
}

public class PaymentCreateDto : IDto
{
    public decimal Amount { get; set; }
    public string Description { get; set; } = null!;
    public int PackageId { get; set; }
}



public class PaymentResponseDto : IDto
{
    public int PaymentId { get; set; }
    public PackageDto Order { get; set; } = null!;
}

