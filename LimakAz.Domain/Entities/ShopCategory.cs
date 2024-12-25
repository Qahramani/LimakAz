namespace LimakAz.Domain.Entities;

public class ShopCategory : BaseEntity
{
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int ShopId { get; set; }
    public Shop? Shop { get; set; }
  
}

