using LimakAz.Domain.Enums;

namespace LimakAz.Domain.Entities;

public class Package : BaseAuditableEntity
{
    public string? NO { get; set; }
    public decimal TotalWeigth { get; set; }
    public decimal TotalCargoPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public string UserId { get; set; } = null!;
    public AppUser? User { get; set; }
    public int PaymentId { get; set; }
    public Payment? Payment { get; set; }
    public int? LocalPointId { get; set; }
    public LocalPoint? LocalPoint { get; set; }
    public int? CountryId { get; set; }
    public Country? Country { get; set; }
    public int? StatusId { get; set; }
    public Status? Status { get; set; }
    public List<OrderItem> OrderItems { get; set; } = [];

}