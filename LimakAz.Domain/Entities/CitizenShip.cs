namespace LimakAz.Domain.Entities;

public class CitizenShip : BaseEntity
{
    public ICollection<CitizenShipDetail> CitizenShipDetails { get; set; } = [];
}
