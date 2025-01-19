namespace LimakAz.Domain.Entities;

public class Order : BaseAuditableEntity
{
    public string Link { get; set; } = null!;
    public decimal Price { get; set; }
    public bool IsLocalCargoFree { get; set; }
    public decimal LocalCargoPrice { get; set; }
    public decimal TotalCargoPrice { get; set; }
    public int Count { get; set; } 
    public string Color { get; set; } = null!;
    public string Size { get; set; } = null!;
    public string Notes { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public AppUser? User { get; set; }
    public int CountryId { get; set; }
    public Country? Country { get; set; }
    public int? ShopId { get; set; }
    public Shop? Shop { get; set; }
    public int LocalPointId { get; set; }
    public LocalPoint? LocalPoint { get; set; }
    public int StatusId { get; set; }
    public Status? Status { get; set; } 
}
