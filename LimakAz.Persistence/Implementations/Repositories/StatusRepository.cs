using LimakAz.Persistence.Contexts;

namespace LimakAz.Persistence.Implementations.Repositories;

internal class StatusRepository : Repository<Status>, IStatusRepository
{
    public StatusRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}