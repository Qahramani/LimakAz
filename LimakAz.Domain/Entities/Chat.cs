namespace LimakAz.Domain.Entities;

public class Chat : BaseAuditableEntity
{
    public string UserId { get; set; } = null!;
    public AppUser? User { get; set; }
    public string ModeratorId { get; set; } = null!;
    public AppUser? Moderator { get; set; }
    public bool IsActive { get; set; }
    public ICollection<Message> Messages { get; set; } = [];
}
