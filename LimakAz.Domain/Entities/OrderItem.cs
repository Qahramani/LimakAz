namespace LimakAz.Domain.Entities;

public class OrderItem : BaseAuditableEntity
{
    public string Link { get; set; } = null!;
    public decimal ItemPrice { get; set; }
    public decimal LocalCargoPrice { get; set; } = 0; //musteri ozu daxil edir
    public decimal CargoPrice { get; set; } // cekiye gore admin hesablayacaq
    public decimal OrderItemTotalPrice { get; set; } // musteri sifaris edende say,localcargo ve mexsulun qiymetine gore cixarcacaq ve odenis edeceq
    public decimal Weight { get; set; }
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
    public int StatusId { get; set; }
    public Status? Status { get; set; }
    public int? PackageId { get; set; }
    public Package? Package { get; set; }
}
