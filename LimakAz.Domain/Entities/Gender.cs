namespace LimakAz.Domain.Entities;

public class Gender : BaseEntity
{
    public ICollection<GenderDetail> GenderDetails { get; set; } = [];
}
