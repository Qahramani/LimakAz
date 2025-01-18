namespace LimakAz.Domain.Entities;

public class Notification : BaseAuditableEntity
{
    public ICollection<NotificationDetail> NotificationDetails { get; set; } = [];
}
