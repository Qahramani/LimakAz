namespace LimakAz.Domain.Entities;

public class CitizenShipDetail : BaseEntity
{
    public string Name { get; set; } = null!;
    public int CitizenShipId { get; set; }
    public CitizenShip? CitizenShip{ get; set; }
    public int LanguageId { get; set; }
    public Language? Language { get; set; }
}
