namespace LimakAz.Domain.Entities;

public class Language : BaseEntity 
{
    public string Name { get; set; } = null!;
    public string IsoCode { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
}
