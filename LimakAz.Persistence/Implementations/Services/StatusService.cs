using LimakAz.Domain.Entities;
using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace LimakAz.Persistence.Implementations.Services;

internal class StatusService : IStatusService
{
    private readonly IStatusRepository _repository;
    private readonly IMapper _mapper;

    public StatusService(IStatusRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> CreateAsync(StatusCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var status = _mapper.Map<Status>(dto);

        await _repository.CreateAsync(status);

        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var status = await _repository.GetAsync(id);

        if(status == null)
            throw new NotFoundException();

         _repository.HardDelete(status);

        await _repository.SaveChangesAsync();
    }

    public List<StatusGetDto> GetAll(LanguageType language = LanguageType.Azerbaijan)
    {
        var statuses = _repository.GetAll(include: _getWithIncludes(language));

        var dtos = _mapper.Map<List<StatusGetDto>>(statuses);

        return dtos;
    }

    private static Func<IQueryable<Status>, IIncludableQueryable<Status, object>> _getWithIncludes(LanguageType language)
    {
        return x => x.Include(x => x.StatusDetails.Where(x => x.LanguageId == (int)language));
    }
    private static Func<IQueryable<Status>, IIncludableQueryable<Status, object>> _getWithIncludes()
    {
        return x => x.Include(x => x.StatusDetails);
    }

    public async Task<StatusGetDto> GetAsync(int id, LanguageType language = LanguageType.Azerbaijan)
    {
        var status = await _repository.GetAsync(x => x.Id == id,_getWithIncludes(language));

        if (status == null)
            throw new NotFoundException();

        var dto = _mapper.Map<StatusGetDto>(status);

        return dto;
    }

    public async Task<PaginateDto<StatusGetDto>> GetPagesAsync(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10)
    {
        var query = _repository.GetAll(include: _getWithIncludes(language));

        var count = query.Count();

        var pageCount = (int)Math.Ceiling((decimal)count / limit);

        if (page > pageCount)
            page = pageCount;

        if (page < 1)
            page = 1;

        query = _repository.Paginate(query, limit, page);

        var statuses = await query.ToListAsync();

        var dtos = _mapper.Map<List<StatusGetDto>>(statuses);

        PaginateDto<StatusGetDto> paginateDto = new()
        {
            Items = dtos,
            CurrentPage = page,
            PageCount = pageCount
        };

        return paginateDto;
    }

    public async Task<StatusUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var status = await _repository.GetAsync(x => x.Id == id, _getWithIncludes());

        if (status == null)
            throw new NotFoundException();

        var dto = _mapper.Map<StatusUpdateDto>(status);

        return dto;
    }

    public Task<bool> IsExistAsync(int id)
    {
        return _repository.IsExistAsync(x => x.Id ==  id);  
    }

    public async Task<bool> UpdateAsync(StatusUpdateDto dto, ModelStateDictionary ModelState)
    {
        if(!ModelState.IsValid)
            return false;

        var status = await _repository.GetAsync(x => x.Id ==  dto.Id, _getWithIncludes());

        if (status == null)
            throw new NotFoundException();

        status = _mapper.Map(dto,status);

        _repository.Update(status);
        await _repository.SaveChangesAsync();

        return true;
    }
}
