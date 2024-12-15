namespace LimakAz.Domain.Entities;

public class Category : BaseAuditableEntity
{
    public string LogoPath { get; set; } = null!;
    public ICollection<CategoryDetail> CategoryDetails { get; set; } = [];
}

