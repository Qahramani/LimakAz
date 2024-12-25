using LimakAz.Persistence.Contexts;

namespace LimakAz.Persistence.Implementations.Repositories;

internal class ShopRepository : Repository<Shop>, IShopRepository
{
    public ShopRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}

