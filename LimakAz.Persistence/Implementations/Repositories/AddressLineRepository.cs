using LimakAz.Persistence.Contexts;

namespace LimakAz.Persistence.Implementations.Repositories;

internal class AddressLineRepository : Repository<AddressLine>, IAddressLineRepository
{
    public AddressLineRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
