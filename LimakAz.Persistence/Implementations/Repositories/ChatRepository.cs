using LimakAz.Persistence.Contexts;

namespace LimakAz.Persistence.Implementations.Repositories;

internal class ChatRepository : Repository<Chat>, IChatRepository
{
    public ChatRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
