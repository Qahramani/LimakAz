using LimakAz.Persistence.Contexts;

namespace LimakAz.Persistence.Implementations.Repositories;

internal class CitizenShipRepository : Repository<CitizenShip>, ICitizenShipRepository
{
    public CitizenShipRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
