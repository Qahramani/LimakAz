namespace LimakAz.Domain.Entities;

public class Message : BaseAuditableEntity
{
    public string Text { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public AppUser? User { get; set; }
    public int ChatId { get; set; }
    public Chat? Chat { get; set; }
}
