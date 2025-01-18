using LimakAz.Persistence.Contexts;

namespace LimakAz.Persistence.Implementations.Repositories;

internal class NotificationRepository : Repository<Notification>, INotificationRepository
{
    public NotificationRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}