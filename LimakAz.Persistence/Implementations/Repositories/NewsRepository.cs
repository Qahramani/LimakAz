using LimakAz.Persistence.Contexts;

namespace LimakAz.Persistence.Implementations.Repositories;

internal class NewsRepository : Repository<News>, INewsRepository
{
    public NewsRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}