using LimakAz.Persistence.Contexts;

namespace LimakAz.Persistence.Implementations.Repositories;

internal class ContentRepository : Repository<Content>, IContentRepository
{
    public ContentRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}