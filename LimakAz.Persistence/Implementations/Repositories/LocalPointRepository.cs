using LimakAz.Persistence.Contexts;

namespace LimakAz.Persistence.Implementations.Repositories;

internal class LocalPointRepository : Repository<LocalPoint>, ILocalPointRepository
{
    public LocalPointRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
