namespace LimakAz.Domain.Entities;

public class Notification : BaseAuditableEntity
{
    public DateTime? SentTime { get; set; }
    public List<NotificationDetail> NotificationDetails { get; set; } = [];
}
