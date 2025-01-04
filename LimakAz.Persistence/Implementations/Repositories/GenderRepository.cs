using LimakAz.Persistence.Contexts;

namespace LimakAz.Persistence.Implementations.Repositories;

internal class GenderRepository : Repository<Gender>, IGenderRepository
{
    public GenderRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
