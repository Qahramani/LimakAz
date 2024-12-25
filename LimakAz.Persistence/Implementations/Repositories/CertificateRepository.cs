using LimakAz.Persistence.Contexts;

namespace LimakAz.Persistence.Implementations.Repositories;

internal class CertificateRepository : Repository<Certificate>, ICertificateRepository
{
    public CertificateRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
