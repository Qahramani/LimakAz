using LimakAz.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace LimakAz.Persistence.Implementations.Services;

internal class TariffService : ITariffService
{
    private readonly ITariffRepository _repository;
    private readonly IMapper _mapper;

    public TariffService(ITariffRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public List<TariffGetDto> GetAll()
    {
        var tariffs = _repository.GetAll();

        var dtos = _mapper.Map<List<TariffGetDto>>(tariffs);

        return dtos;
    }

    public async Task<PaginateDto<TariffGetDto>> GetPagesAsync(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10)
    {
        var query = _repository.GetAll(include: x => x.Include(x => x.TariffDetails.Where(x => x.LanguageId == (int)language)));

        var count = query.Count();

        var pageCount = (int)Math.Ceiling((decimal)count / limit);

        if (page > pageCount)
            page = pageCount;

        if (page < 1)
            page = 1;
        

        query = _repository.Paginate(query, limit, page);

        query.OrderByDescending(x => x.CreatedAt);

        var certificates = await query.ToListAsync();

        var dtos = _mapper.Map<List<TariffGetDto>>(certificates);

        PaginateDto<TariffGetDto> paginateDto = new()
        {
            Items = dtos,
            CurrentPage = page,
            PageCount = pageCount
        };

        return paginateDto;
    }
}
