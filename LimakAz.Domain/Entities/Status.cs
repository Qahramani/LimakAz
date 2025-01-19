namespace LimakAz.Domain.Entities;

public class Status : BaseEntity
{
    public ICollection<StatusDetail> StatusDetails { get; set; } = [];
    public ICollection<Order> Orders { get; set; } = [];
}
