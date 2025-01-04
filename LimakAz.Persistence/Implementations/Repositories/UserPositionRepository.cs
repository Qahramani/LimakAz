using LimakAz.Persistence.Contexts;

namespace LimakAz.Persistence.Implementations.Repositories;

internal class UserPositionRepository : Repository<UserPosition>, IUserPositionRepository
{
    public UserPositionRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
