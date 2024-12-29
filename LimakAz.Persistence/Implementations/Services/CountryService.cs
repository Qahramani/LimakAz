using LimakAz.Application.Interfaces.Services;
using LimakAz.Domain.Enums;
using LimakAz.Persistence.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace LimakAz.Persistence.Implementations.Services;

internal class CountryService : ICountryService
{
    private readonly ICountryRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILanguageService _languageService;
    private readonly ICloudinaryService _cloudinaryService;
    public CountryService(ICountryRepository countryRepository, IMapper mapper, ILanguageService languageService, ICloudinaryService cloudinaryService)
    {
        this._repository = countryRepository;
        _mapper = mapper;
        _languageService = languageService;
        _cloudinaryService = cloudinaryService;
    }

    public List<CountryGetDto> GetAll(LanguageType language = LanguageType.Azerbaijan)
    {
        var countries = _repository.GetAll(include: _getWithIncludes(language));

        var dtos = _mapper.Map<List<CountryGetDto>>(countries);

        return dtos;
    }

    public async Task<PaginateDto<CountryGetDto>> GetPagesAsync(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10)
    {

        var query = _repository.GetAll(include:_getWithIncludes(language));

        var count = query.Count();

        var pageCount = (int)Math.Ceiling((decimal)count / limit);

        if (page > pageCount)
            page = pageCount;

        if (page < 1)
            page = 1;

        query = _repository.Paginate(query, limit, page);

        query.OrderBy(x => x.Tariffs.FirstOrDefault()!.MinValue);

        var countries = await query.ToListAsync();

        var dtos = _mapper.Map<List<CountryGetDto>>(countries);

        PaginateDto<CountryGetDto> paginateDto = new()
        {
            Items = dtos,
            CurrentPage = page,
            PageCount = pageCount
        };

        return paginateDto;
    }

   
    public async Task<bool> CreateAsync(CountryCreateDto dto, ModelStateDictionary ModelState)
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

        var existingCountyName = await _repository.GetAsync(x => x.CountryDetails.FirstOrDefault()!.Name.ToLower() == dto.CountryDetails.FirstOrDefault()!.Name!.ToLower());

        if (existingCountyName != null)
        {
            ModelState.AddModelError("", "Bu adda ölkə mövcuddur");
            return false;
        }

        foreach (var detail in dto.CountryDetails)
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

        var country = _mapper.Map<Country>(dto);

        await _repository.CreateAsync(country);

        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(CountryUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var country = await _repository.GetAsync(x => x.Id == dto.Id, x => x.Include(x => x.CountryDetails));

        if (country == null)
            throw new NotFoundException();

        var existingCountryName = await _repository.GetAsync(x => x.CountryDetails.FirstOrDefault()!.Name.ToLower() == dto.CountryDetails.FirstOrDefault()!.Name!.ToLower() && x.Id != dto.Id);

        if (existingCountryName != null)
        {
            ModelState.AddModelError("", "Bu adda ölkə mövcuddur");
            return false;
        }

        foreach (var detail in dto.CountryDetails)
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

            await _cloudinaryService.FileDeleteAsync(country.ImagePath);

            var imagePath = await _cloudinaryService.FileCreateAsync(dto.ImageFile);

            country.ImagePath = imagePath;
        }

        country = _mapper.Map(dto, country);

        _repository.Update(country);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task<CountryUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var news = await _repository.GetAsync(x => x.Id == id, _getWithIncludes());

        if (news == null)
            throw new NotFoundException();

        var dto = _mapper.Map<CountryUpdateDto>(news);

        return dto;
    }

    public async Task DeleteAsync(int id)
    {
        var country = await _repository.GetAsync(id);

        if (country == null)
            throw new NotFoundException();

        _repository.SoftDelete(country);
    }

    private static Func<IQueryable<Country>, IIncludableQueryable<Country, object>> _getWithIncludes(LanguageType language)
    {
        return x => x.Include(x => x.CountryDetails.Where(x => x.LanguageId == (int)language)).Include(x => x.Tariffs);
    }
    private static Func<IQueryable<Country>, IIncludableQueryable<Country, object>> _getWithIncludes()
    {
        return x => x.Include(x => x.CountryDetails).Include(x => x.Tariffs);
    }

    public async Task<CountryGetDto?> GetAsync(int Id)
    {
        var country = await _repository.GetAsync(Id);

        var dto = _mapper.Map<CountryGetDto>(country);

        return dto;
    }

    public async Task<CountryGetDto> GetAsync(int id, LanguageType language = LanguageType.Azerbaijan)
    {
        var country = await _repository.GetAsync(x => x.Id == id, _getWithIncludes());

        if (country == null)
            throw new NotFoundException();

        var dto = _mapper.Map<CountryGetDto>(country);

        return dto;
    }

    public async Task<bool> IsExistAsync(int id)
    {
        return await _repository.IsExistAsync(x => x.Id == id);
    }
}
