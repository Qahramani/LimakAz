namespace LimakAz.Domain.Entities;

public class WareHouseDetail : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string AddressLine { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string WorkingHourse { get; set; } = null!;
    public int LocationId { get; set; }
    public WareHouse? Location { get; set; }
    public int LanguageId { get; set; }
    public Language? Language { get; set; }
}