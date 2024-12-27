using LimakAz.Persistence.Contexts;

namespace LimakAz.Persistence.Implementations.Repositories;

internal class TariffRepository : Repository<Tariff>, ITariffRepository
{
    public TariffRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
