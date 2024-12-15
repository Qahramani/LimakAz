namespace LimakAz.Domain.Entities;

public class Country : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Currency { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
}

