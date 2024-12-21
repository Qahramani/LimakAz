using LimakAz.Application.Interfaces.Repositories;
using LimakAz.Persistence.Contexts;

namespace LimakAz.Persistence.Implementations.Repositories;

internal class SettingRepository : Repository<Setting>, ISettingRepository
{
    public SettingRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
