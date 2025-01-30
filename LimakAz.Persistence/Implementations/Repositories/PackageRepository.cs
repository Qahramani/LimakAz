using LimakAz.Persistence.Contexts;

namespace LimakAz.Persistence.Implementations.Repositories;

internal class PackageRepository : Repository<Package>, IPackageRepository
{
    public PackageRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
