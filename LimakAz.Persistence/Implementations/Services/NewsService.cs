using LimakAz.Application.Interfaces.Services;
using LimakAz.Domain.Enums;
using LimakAz.Persistence.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

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

        if (!dto.ImageFile.CheckSize())
        {
            ModelState.AddModelError("", "Şəkilin həcmi böyükdür");
            return false;
        }
        if (!dto.ImageFile.CheckType())
        {
            ModelState.AddModelError("", "Doğru şəkil formatı daxil edin");
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
        var imagePath = await _cloudinaryService.FileCreateAsync(dto.ImageFile);

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
    }

    public List<NewsGetDto> GetAll()
    {
        var newslist = _repository.GetAll();

        var dtos = _mapper.Map<List<NewsGetDto>>(newslist);

        return dtos;
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

        query.OrderByDescending(x => x.CreatedAt);

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

    public async Task<bool> UpdateAsync(NewsUpdateDto dto, ModelStateDictionary ModelState)
    {

        if (!ModelState.IsValid)
            return false;

        
        var news = await _repository.GetAsync(x => x.Id == dto.Id, x => x.Include(x => x.NewsDetails));

        if (news == null)
            throw new NotFoundException();

        if (dto.ImageFile != null)
        {
            if (!dto.ImageFile.CheckSize())
            {
                ModelState.AddModelError("", "Şəkilin həcmi böyükdür");
                return false;
            }
            if (!dto.ImageFile.CheckType())
            {
                ModelState.AddModelError("", "Doğru şəkil formatı daxil edin");
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
