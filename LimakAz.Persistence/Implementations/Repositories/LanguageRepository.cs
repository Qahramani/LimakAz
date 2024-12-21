using LimakAz.Application.Interfaces.Repositories;
using LimakAz.Persistence.Contexts;

namespace LimakAz.Persistence.Implementations.Repositories;

internal class LanguageRepository : Repository<Language>, ILanguageRepository
{
    public LanguageRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}