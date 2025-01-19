namespace LimakAz.Domain.Entities;

public class StatusDetail : BaseEntity
{
    public string Name { get; set; } = null!;
    public int StatusId { get; set; }
    public Status? Status { get; set; }
    public int LanguageId { get; set; }
    public Language? Language { get; set; }
}