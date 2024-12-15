namespace LimakAz.Domain.Entities;

public class News : BaseAuditableEntity
{
    public string ImagePath { get; set; } = null!;
    public ICollection<NewsDetail> NewsDetails { get; set; } = [];

}
