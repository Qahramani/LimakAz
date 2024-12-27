using LimakAz.Persistence.Contexts;

namespace LimakAz.Persistence.Implementations.Repositories;

internal class CountryRepository : Repository<Country>, ICountryRepository
{
    public CountryRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
