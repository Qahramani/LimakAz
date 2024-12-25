namespace LimakAz.Domain.Entities;

public class WareHouse : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string AddressLine { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string WorkingHourse { get; set; } = null!;
   // public ICollection<WareHouseDetail> LocationDetails { get; set; } = [];
}
