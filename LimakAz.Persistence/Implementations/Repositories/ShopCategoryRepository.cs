using LimakAz.Persistence.Contexts;

namespace LimakAz.Persistence.Implementations.Repositories;

internal class ShopCategoryRepository : Repository<ShopCategory>, IShopCategoryRepository
{
    public ShopCategoryRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}

