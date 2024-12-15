namespace LimakAz.Domain.Entities;

public class Location : BaseEntity
{
    public ICollection<LocationDetail> LocationDetails { get; set; } = [];
}
