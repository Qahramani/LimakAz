using LimakAz.Persistence.Contexts;

namespace LimakAz.Persistence.Implementations.Repositories;

internal class SliderRepository : Repository<Slider>, ISliderRepository
{
    public SliderRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
