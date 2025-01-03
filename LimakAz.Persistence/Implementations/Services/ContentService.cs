using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace LimakAz.Persistence.Implementations.Services;

internal class ContentService : IContentService
{
    private readonly IContentRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILanguageService _languageService;

    public ContentService(IContentRepository repository, IMapper mapper, ILanguageService languageService)
    {
        _repository = repository;
        _mapper = mapper;
        _languageService = languageService;
    }

    public async Task<bool> CreateAsync(ContentCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;
        foreach (var detail in dto.ContentDetails)
        {
            var existLanguage = await _languageService.GetLanguageAsync(x => x.Id == detail.LanguageId);

            if (existLanguage == null)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }
        }

        var content = _mapper.Map<Content>(dto);

        await _repository.CreateAsync(content);

        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var country = await _repository.GetAsync(id);

        if (country == null)
            throw new NotFoundException();

        _repository.SoftDelete(country);

        await _repository.SaveChangesAsync();
    }

    public List<ContentGetDto> GetAll(LanguageType language = LanguageType.Azerbaijan)
    {
        var countries = _repository.GetAll(include: _getWithIncludes());

        var dtos = _mapper.Map<List<ContentGetDto>>(countries);

        return dtos;
    }

   

    public async Task<ContentGetDto> GetAsync(int id, LanguageType language = LanguageType.Azerbaijan)
    {
        var country = await _repository.GetAsync(x => x.Id == id, _getWithIncludes());

        var dto = _mapper.Map<ContentGetDto>(country);

        return dto;
    }

    public async Task<PaginateDto<ContentGetDto>> GetPagesAsync(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10)
    {
        var query = _repository.GetAll(include: (Func<IQueryable<Content>, IIncludableQueryable<Content, object>>?)_getWithIncludes(language));

        var count = query.Count();

        var pageCount = (int)Math.Ceiling((decimal)count / limit);

        if (page > pageCount)
            page = pageCount;

        if (page < 1)
            page = 1;

        query = _repository.Paginate(query, limit, page);

        query.OrderByDescending(x => x.CreatedAt);

        var content = await query.ToListAsync();

        var dtos = _mapper.Map<List<ContentGetDto>>(content);

        PaginateDto<ContentGetDto> paginateDto = new()
        {
            Items = dtos,
            CurrentPage = page,
            PageCount = pageCount
        };

        return paginateDto;
    }


    public async Task<ContentUpdateDto> GetUpdatedDtoAsync(int id)
    {

        var news = await _repository.GetAsync(x => x.Id == id, _getWithIncludes());

        if (news == null)
            throw new NotFoundException();

        var dto = _mapper.Map<ContentUpdateDto>(news);

        return dto;
    }

    public async Task<bool> IsExistAsync(int id)
    {
        return await _repository.IsExistAsync(x => x.Id == id);
    }

    public async Task<bool> UpdateAsync(ContentUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var content = await _repository.GetAsync(x => x.Id == dto.Id, _getWithIncludes());

        if(content == null)
            throw new NotFoundException();

        foreach (var detail in dto.ContentDetails)
        {
            var existLanguage = await _languageService.GetLanguageAsync(x => x.Id == detail.LanguageId);

            if (existLanguage == null)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }
        }

         content = _mapper.Map(dto,content);

         _repository.Update(content);

        await _repository.SaveChangesAsync();

        return true;
    }


    private static Func<IQueryable<Content>, IIncludableQueryable<Content, object>> _getWithIncludes(LanguageType language)
    {
        return x => x.Include(x => x.ContentDetails.Where(x => x.LanguageId == (int)language));
    }
    private static Func<IQueryable<Content>, IIncludableQueryable<Content, object>> _getWithIncludes()
    {
        return x => x.Include(x => x.ContentDetails);
    }

    public List<ContentGetDto> GetByPageType(PageType pageType, LanguageType language)
    {
        var contents = _repository.GetAll(x => x.PageType == pageType , _getWithIncludes(language));

        var dtos = _mapper.Map<List<ContentGetDto>>(contents);

        return dtos;
    }
}
