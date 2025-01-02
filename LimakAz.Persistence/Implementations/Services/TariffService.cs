using LimakAz.Application.Interfaces.Services.External;
using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace LimakAz.Persistence.Implementations.Services;

internal class TariffService : ITariffService
{
    private readonly ITariffRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICountryService _countryService;
    private readonly ILocalPointService _localPointService;
    private readonly ICurrencyService _currencyService;

    public TariffService(ITariffRepository repository, IMapper mapper, ICountryService countryService, ILocalPointService localPointService, ICurrencyService currencyService)
    {
        _repository = repository;
        _mapper = mapper;
        _countryService = countryService;
        _localPointService = localPointService;
        _currencyService = currencyService;
    }



    public async Task<bool> CreateAsync(TariffCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        if (dto.MinValue < 0 || dto.MaxValue < 0 || dto.MinValue >= dto.MaxValue)
        {
            ModelState.AddModelError("", "Ceki ucun duzgun deyerler elave ediniz");
            return false;
        }

        if (dto.Price < 0)
        {
            ModelState.AddModelError("", "Duzgun Mebleq elave ediniz");
            return false;
        }

        var isExistRange = await _repository.IsExistAsync(x => !(x.MaxValue < dto.MinValue || x.MinValue > dto.MaxValue) && x.CountryId == dto.CountryId);

        if (isExistRange)
        {
            ModelState.AddModelError("", "Bu kilo araliginda tariff mevcuddur");
            return false;
        }

        var tariff = _mapper.Map<Tariff>(dto);
        await _repository.CreateAsync(tariff);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var tariff = await _repository.GetAsync(id);

        if (tariff == null)
            throw new NotFoundException();

        _repository.SoftDelete(tariff);
        await _repository.SaveChangesAsync();
    }

    public List<TariffGetDto> GetAll(LanguageType language = LanguageType.Azerbaijan)
    {
        var tariffs = _repository.GetAll();

        var dtos = _mapper.Map<List<TariffGetDto>>(tariffs);

        return dtos;
    }

    public async Task<TariffGetDto> GetAsync(int id, LanguageType language = LanguageType.Azerbaijan)
    {
        var tariff = await _repository.GetAsync(x => x.Id == id);

        if (tariff == null)
            throw new NotFoundException();

        var dto = _mapper.Map<TariffGetDto>(tariff);

        return dto;
    }

    public async Task<PaginateDto<TariffGetDto>> GetPagesAsync(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10)
    {
        var query = _repository.GetAll();

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
    public async Task<List<TariffGetDto>> GetTariffsByCountry(int countryId, LanguageType language = LanguageType.Azerbaijan)
    {
        var existingCountry = await _countryService.GetAsync(countryId);

        if (existingCountry == null)
            throw new NotFoundException("Bu Id de olke tapilmadi");

        var tariffs = _repository.GetAll(x => x.CountryId == countryId);

        tariffs.OrderBy(x => x.MinValue);

        var dtos = _mapper.Map<List<TariffGetDto>>(tariffs);

        return dtos;
    }

    public async Task<List<TariffUiGetDto>> GetTariffsUiDtosAsync(LanguageType language = LanguageType.Azerbaijan)
    {
        var countries =  _countryService.GetAll(language);
        var points = _localPointService.GetAll(language);
        List<TariffUiGetDto> dtos = [];

        var UsdCoefficient = await  _currencyService.GetCurrencyCoefficientAsync("USD");

        foreach (var country in countries)
        {

            TariffUiGetDto dto = new();

            dto.CountryName = country.CountryDetails.FirstOrDefault()!.Name;
            dto.ImagePath = country.ImagePath;
            dto.LocalPoints = points.Select(x => x.LocalPointDetails.FirstOrDefault()?.Name).ToList()!;

            foreach (var tariff in country.Tariffs)
            {
                dto.Tariffs.Add(new FormattedTariffGetDto
                {
                    Value = $"{tariff.MinValue} - {tariff.MaxValue}",
                    PriceInAZN = $"{tariff.Price} AZN",
                    PriceInUSD = $"{Math.Round(tariff.Price / UsdCoefficient, 2)} USD"
                });
            }
            
            dtos.Add(dto);
        }

        return dtos;
    }

    public async Task<TariffUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var tariff = await _repository.GetAsync(id);

        if (tariff == null)
            throw new NotFoundException();

        var dto = _mapper.Map<TariffUpdateDto>(tariff);

        return dto;
    }

    public async Task<bool> IsExistAsync(int id)
    {
        return await _repository.IsExistAsync(x => x.Id == id);
    }

    public async Task<bool> UpdateAsync(TariffUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;


        var isExistRange = await _repository.IsExistAsync(x => !(x.MaxValue < dto.MinValue || x.MinValue > dto.MaxValue) && x.Id != dto.Id && x.CountryId == dto.CountryId);

        if (isExistRange)
        {
            ModelState.AddModelError("", "Bu kilo araliginda tariff mevcuddur");
            return false;
        }

        var isCountryExist = await _countryService.GetAsync(dto.CountryId);

        if (isCountryExist == null)
            throw new NotFoundException("Bu Id de olke tapilmadi");

        var tariff = await _repository.GetAsync(dto.Id);

        if (tariff == null)
            throw new NotFoundException();

        tariff = _mapper.Map(dto, tariff);
        _repository.Update(tariff);
        await _repository.SaveChangesAsync();

        return true;
    }


}
