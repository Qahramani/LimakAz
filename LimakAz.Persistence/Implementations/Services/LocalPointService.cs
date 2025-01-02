using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace LimakAz.Persistence.Implementations.Services;

internal class LocalPointService : ILocalPointService
{
    private readonly ILocalPointRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILanguageService _languageService;

    public LocalPointService(ILocalPointRepository repository, IMapper mapper, ILanguageService languageService)
    {
        _repository = repository;
        _mapper = mapper;
        _languageService = languageService;
    }

    public async Task<bool> CreateAsync(LocalPointCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var isAlreadyExist = await _repository.IsExistAsync(x => x.LocalPointDetails.FirstOrDefault()!.Name.ToLower() == dto.LocalPointDetails.FirstOrDefault()!.Name!.ToLower());

        if (isAlreadyExist)
        {
            ModelState.AddModelError("", "Bu adda yer mövcuddur");
            return false;
        }

        foreach (var detail in dto.LocalPointDetails)
        {
            var existLanguage = await _languageService.GetLanguageAsync(x => x.Id == detail.LanguageId);

            if (existLanguage == null)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }
        }

        var point = _mapper.Map<LocalPoint>(dto);

        await _repository.CreateAsync(point);

        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var point = await _repository.GetAsync(id);

        if (point == null)
            throw new NotFoundException();

        _repository.SoftDelete(point);

        await _repository.SaveChangesAsync();
    }

    public List<LocalPointGetDto> GetAll(LanguageType language = LanguageType.Azerbaijan)
    {
        var points = _repository.GetAll(include: _getWithIncludes(language));

        var dtos = _mapper.Map<List<LocalPointGetDto>>(points);

        return dtos;
    }


    public async Task<LocalPointGetDto> GetAsync(int id, LanguageType language = LanguageType.Azerbaijan)
    {
        var point = await _repository.GetAsync(id);

        var dto = _mapper.Map<LocalPointGetDto>(point);

        return dto;
    }

    public async Task<PaginateDto<LocalPointGetDto>> GetPagesAsync(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10)
    {


        var query = _repository.GetAll(include: _getWithIncludes(language));

        var count = query.Count();

        var pageCount = (int)Math.Ceiling((decimal)count / limit);

        if (page > pageCount)
            page = pageCount;

        if (page < 1)
            page = 1;

        query = _repository.Paginate(query, limit, page);

        var points = await query.ToListAsync();

        var dtos = _mapper.Map<List<LocalPointGetDto>>(points);

        PaginateDto<LocalPointGetDto> paginateDto = new()
        {
            Items = dtos,
            CurrentPage = page,
            PageCount = pageCount
        };

        return paginateDto;
    }



    public async Task<bool> IsExistAsync(int id)
    {
        return await _repository.IsExistAsync(x => x.Id == id);
    }

    public async Task<bool> UpdateAsync(LocalPointUpdateDto dto, ModelStateDictionary ModelState)
    {

        if (!ModelState.IsValid)
            return false;

        var point = await _repository.GetAsync(x => x.Id == dto.Id, include: _getWithIncludes());

        if (point == null)
            throw new NotFoundException();

        var isAlreadyExist = await _repository.IsExistAsync(x => x.LocalPointDetails.FirstOrDefault()!.Name.ToLower() == dto.LocalPointDetails.FirstOrDefault()!.Name!.ToLower() && x.Id != dto.Id);

        if (isAlreadyExist)
        {
            ModelState.AddModelError("", "Bu adda yer mövcuddur");
            return false;
        }

        foreach (var detail in dto.LocalPointDetails)
        {
            var existLanguage = await _languageService.GetLanguageAsync(x => x.Id == detail.LanguageId);

            if (existLanguage == null)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }
        }

        point = _mapper.Map(dto, point);

        _repository.Update(point);

        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task<LocalPointUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var points = await _repository.GetAsync(x => x.Id == id, _getWithIncludes());

        if (points == null)
            throw new NotFoundException();

        var dto = _mapper.Map<LocalPointUpdateDto>(points);

        return dto;
    }

    private static Func<IQueryable<LocalPoint>, IIncludableQueryable<LocalPoint, object>> _getWithIncludes(LanguageType language)
    {
        return x => x.Include(x => x.LocalPointDetails.Where(x => x.LanguageId == (int)language));
    }
    private static Func<IQueryable<LocalPoint>, IIncludableQueryable<LocalPoint, object>> _getWithIncludes()
    {
        return x => x.Include(x => x.LocalPointDetails);
    }
}