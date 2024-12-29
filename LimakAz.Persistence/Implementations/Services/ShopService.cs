using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LimakAz.Persistence.Implementations.Services;

internal class ShopService : IShopService
{
    private readonly IShopRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICountryService _countryService;
    private readonly ICategoryService _categoryService;

    public ShopService(IShopRepository repository, IMapper mapper, ICountryService countryService, ICategoryService categoryService)
    {
        _repository = repository;
        _mapper = mapper;
        _countryService = countryService;
        _categoryService = categoryService;
    }

    public Task<bool> CreateAsync(ShopCreateDto dto, ModelStateDictionary ModelState)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public List<ShopGetDto> GetAll(LanguageType language = LanguageType.Azerbaijan)
    {
        throw new NotImplementedException();
    }

    public async Task<ShopCreateDto> GetCreateDto()
    {
        var countries =  _countryService.GetAll();
        var categories = _categoryService.GetAll();

        

    public Task<PaginateDto<ShopGetDto>> GetPagesAsync(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10)
    {
        throw new NotImplementedException();
    }

    public Task<ShopUpdateDto> GetUpdatedDtoAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(ShopUpdateDto dto, ModelStateDictionary ModelState)
    {
        throw new NotImplementedException();
    }
}
