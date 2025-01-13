using LimakAz.Application.Interfaces.Services.External;
using LimakAz.Domain.Entities;
using LimakAz.Domain.Enums;
using LimakAz.Persistence.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace LimakAz.Persistence.Implementations.Services;

internal class NewsService : INewsService
{
    private readonly INewsRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;
    private readonly ILanguageService _languageService;

    public NewsService(INewsRepository repository, IMapper mapper, ICloudinaryService cloudinaryService, ILanguageService languageService)
    {
        _repository = repository;
        _mapper = mapper;
        _cloudinaryService = cloudinaryService;
        _languageService = languageService;
    }

    public async Task<bool> CreateAsync(NewsCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        if (!dto.ImageFile!.CheckSize())
        {
            ModelState.AddModelError("", "Şəkilin həcmi böyükdür");
            return false;
        }
        if (!dto.ImageFile!.CheckType())
        {
            ModelState.AddModelError("", "Şəkil formatı yanlışdır");
            return false;
        }

        foreach (var detail in dto.NewsDetails)
        {
            var existLanguage = await _languageService.GetLanguageAsync(x => x.Id == detail.LanguageId);

            if (existLanguage == null)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }
        }
        var imagePath = await _cloudinaryService.FileCreateAsync(dto.ImageFile!);

        dto.ImagePath = imagePath;

        var news = _mapper.Map<News>(dto);

        await _repository.CreateAsync(news);

        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var news = await _repository.GetAsync(id);

        if (news == null)
            throw new NotFoundException();

        _repository.SoftDelete(news);

        await _repository.SaveChangesAsync();
    }

    public List<NewsGetDto> GetAll(LanguageType language = LanguageType.Azerbaijan)
    {
        var newslist = _repository.GetAll(include : x => x.Include(x => x.NewsDetails.Where(x => x.LanguageId == (int)language)));

        var dtos = _mapper.Map<List<NewsGetDto>>(newslist);

        return dtos;
    }

    public async Task<NewsGetDto> GetAsync(int id, LanguageType language = LanguageType.Azerbaijan)
    {
        var news = await _repository.GetAsync(x => x.Id == id, x => x.Include(x => x.NewsDetails.Where(x => x.LanguageId == (int)language)));

        if (news == null)
            throw new NotFoundException();

        var dto = _mapper.Map<NewsGetDto>(news);

        return dto;
    }

    public async Task<NewsDetailsUiDto> GetNewsDetailsUiAsync(int id, LanguageType language = LanguageType.Azerbaijan)
    {
        var selectedNews = await _repository.GetAsync(x => x.Id == id, _getWithIncludes(language));

        if (selectedNews == null)
            throw new NotFoundException();

        var recommendedNews = await _repository.GetAll(x => x.Id != id, _getWithIncludes(language)).Take(5).ToListAsync();

        recommendedNews.OrderByDescending(x => x.UpdatedBy);

        var selectedDto = _mapper.Map<NewsGetDto>(selectedNews);
        var recommendedDtos = _mapper.Map<List<NewsGetDto>>(recommendedNews);

        NewsDetailsUiDto dto = new()
        {
            SelectedNews = selectedDto,
            RecommendedNews = recommendedDtos
        };

        return dto;
    }

    private static Func<IQueryable<News>, IIncludableQueryable<News, object>> _getWithIncludes(LanguageType language)
    {
        return x => x.Include(x => x.NewsDetails.Where(x => x.LanguageId == (int)language));
    }

    public async Task<PaginateDto<NewsGetDto>> GetPagesAsync(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10)
    {
        var query = _repository.GetAll(include : x => x.Include(x => x.NewsDetails.Where(x => x.LanguageId == (int)language)));

        var count = query.Count();

        var pageCount = (int)Math.Ceiling((decimal)count / limit);

        if (page > pageCount)
            page = pageCount;

        if (page < 1)
            page = 1;

        query = _repository.Paginate(query, limit, page);

        query.OrderByDescending(x => x.UpdatedAt);

        var certificates = await query.ToListAsync();

        var dtos = _mapper.Map<List<NewsGetDto>>(certificates);

        PaginateDto<NewsGetDto> paginateDto = new()
        {
            Items = dtos,
            CurrentPage = page,
            PageCount = pageCount
        };

        return paginateDto;
    }

    public async Task<NewsUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var news = await _repository.GetAsync(x => x.Id == id, x => x.Include(x => x.NewsDetails));

        if(news == null)
            throw new NotFoundException();

        var dto = _mapper.Map<NewsUpdateDto>(news);

        return dto;
    }

    public async Task<bool> IsExistAsync(int id)
    {
        return await _repository.IsExistAsync(x => x.Id == id);
    }

    public async Task<bool> UpdateAsync(NewsUpdateDto dto, ModelStateDictionary ModelState)
    {

        if (!ModelState.IsValid)
            return false;
        
        var news = await _repository.GetAsync(x => x.Id == dto.Id, x => x.Include(x => x.NewsDetails));

        if (news == null)
            throw new NotFoundException();

        foreach (var detail in dto.NewsDetails)
        {
            var existLanguage = await _languageService.GetLanguageAsync(x => x.Id == detail.LanguageId);

            if (existLanguage == null)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }
        }

        if (dto.ImageFile != null)
        {
            if (!dto.ImageFile.CheckSize())
            {
                ModelState.AddModelError("", "Şəkilin həcmi böyükdür");
                return false;
            }
            if (!dto.ImageFile.CheckType())
            {
                ModelState.AddModelError("", "Şəkil formatı yanlışdır");
                return false;
            }

            await _cloudinaryService.FileDeleteAsync(news.ImagePath);

            var imagePath = await _cloudinaryService.FileCreateAsync(dto.ImageFile);

            news.ImagePath = imagePath;
        }

        news = _mapper.Map(dto, news);

        _repository.Update(news);
        await _repository.SaveChangesAsync();

        return true;
    }
}
