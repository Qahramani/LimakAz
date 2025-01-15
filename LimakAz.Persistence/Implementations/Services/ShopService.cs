using LimakAz.Application.Interfaces.Services.External;
using LimakAz.Domain.Enums;
using LimakAz.Persistence.Extentions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace LimakAz.Persistence.Implementations.Services;


internal class ShopService : IShopService
{
    private readonly IShopRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICountryService _countryService;
    private readonly ICategoryService _categoryService;
    private readonly ICloudinaryService _cloudinaryService;
    private readonly IShopCategoryService _shopCategoryService;
    public ShopService(IShopRepository repository, IMapper mapper, ICountryService countryService, ICategoryService categoryService, ICloudinaryService cloudinaryService, IShopCategoryService shopCategoryService)
    {
        _repository = repository;
        _mapper = mapper;
        _countryService = countryService;
        _categoryService = categoryService;
        _cloudinaryService = cloudinaryService;
        _shopCategoryService = shopCategoryService;
    }

    public async Task<bool> CreateAsync(ShopCreateDto dto, ModelStateDictionary ModelState)
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

        if (!(await _countryService.IsExistAsync(dto.CountryId)))
        {
            ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
            return false;
        }

        var shop = _mapper.Map<Shop>(dto);

        foreach (var catId in dto.SelectedCategoryIds)
        {
            var existingCategory = await _categoryService.IsExistAsync(catId);

            if (!existingCategory)
            {
                ModelState.AddModelError("", $"{catId}-li kateqoriya tapılmadı");
                return false;
            }

            ShopCategory shopCategory = new()
            {
                CategoryId = catId,
                Shop = shop
            };

            shop.ShopCategories.Add(shopCategory);
        }

        var imagePath = await _cloudinaryService.FileCreateAsync(dto.ImageFile!);

        shop.ImagePath = imagePath;

        await _repository.CreateAsync(shop);

        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var shop = await _repository.GetAsync(id);

        if (shop == null)
            throw new NotFoundException();

        _repository.HardDelete(shop);

        await _repository.SaveChangesAsync();
    }

    public List<ShopGetDto> GetAll(LanguageType language = LanguageType.Azerbaijan)
    {
        var shops = _repository.GetAll(include: _getWithIncludes());

        var dtos = _mapper.Map<List<ShopGetDto>>(shops);

        return dtos;
    }



    public ShopCreateDto GetCreateDto(ShopCreateDto dto)
    {
        var countries = _countryService.GetAll();
        var categories = _categoryService.GetAll();


        dto = new()
        {
            Countries = countries,
            Categories = categories.Select(cat => new SelectListItem
            {
                Text = cat.CategoryDetails.FirstOrDefault()?.Name,
                Value = cat.Id.ToString()
            }).ToList()
        };

        return dto;
    }

    public async Task<PaginateDto<ShopGetDto>> GetPagesAsync(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10)
    {
        var query = _repository.GetAll(include: _getWithIncludes());

        var count = query.Count();

        var pageCount = (int)Math.Ceiling((decimal)count / limit);

        if (page > pageCount)
            page = pageCount;

        if (page < 1)
            page = 1;

        query = _repository.Paginate(query, limit, page);

        var shops = await query.ToListAsync();

        var dtos = _mapper.Map<List<ShopGetDto>>(shops);

        PaginateDto<ShopGetDto> paginateDto = new()
        {
            Items = dtos,
            CurrentPage = page,
            PageCount = pageCount
        };

        return paginateDto;
    }

    public async Task<ShopUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var shop = await _repository.GetAsync(x => x.Id == id, _getWithIncludes());

        if (shop == null)
            throw new NotFoundException();


        var dto = _mapper.Map<ShopUpdateDto>(shop);

        var countries = _countryService.GetAll();
        var categories = _categoryService.GetAll();


        dto.Countries = countries;
        dto.Categories = categories.Select(cat => new SelectListItem
        {
            Text = cat.CategoryDetails.FirstOrDefault()?.Name,
            Value = cat.Id.ToString()
        }).ToList();
        dto.SelectedCategoryIds = shop.ShopCategories.Select(c => c.CategoryId).ToList();

        return dto;
    }

    public async Task<bool> UpdateAsync(ShopUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var shop = await _repository.GetAsync(x => x.Id == dto.Id, _getWithIncludes());

        if(shop == null)
            throw new NotFoundException();

        if (!(await _countryService.IsExistAsync(dto.CountryId)))
        {
            ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
            return false;
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

            await _cloudinaryService.FileDeleteAsync(shop.ImagePath);

            var imagePath = await _cloudinaryService.FileCreateAsync(dto.ImageFile);

            shop.ImagePath = imagePath;
        }

        //kohneleri pozub yenileri elave edirik
        var oldShopCategories =  shop.ShopCategories.Select(x => x.Id).ToList();

        foreach (var catdId in oldShopCategories)
        {
            await _shopCategoryService.DeleteAsync(catdId);

        }

        foreach (var catId in dto.SelectedCategoryIds)
        {
            var existingCategory = await _categoryService.IsExistAsync(catId);

            if (!existingCategory)
            {
                ModelState.AddModelError("", $"{catId}-li kateqoriya tapılmadı");
                return false;
            }

            ShopCategory shopCategory = new()
            {
                CategoryId = catId,
                Shop = shop
            };

            shop.ShopCategories.Add(shopCategory);
        }

        shop = _mapper.Map(dto, shop);

         _repository.Update(shop);

        await _repository.SaveChangesAsync();

        return true;
    }
    private static Func<IQueryable<Shop>, IIncludableQueryable<Shop, object>> _getWithIncludes()
    {
        return x => x.Include(x => x.Country).ThenInclude(x => x!.CountryDetails).Include(x => x.ShopCategories).ThenInclude(x => x.Category).ThenInclude(x => x!.CategoryDetails);
    }



    public async Task<bool> IsExistAsync(int id)
    {
        return await _repository.IsExistAsync(x => x.Id == id);
    }

    public async Task<ShopGetDto> GetAsync(int id, LanguageType language = LanguageType.Azerbaijan)
    {
        var shop = await _repository.GetAsync(x => x.Id == id, _getWithIncludes());

        if (shop == null)
            throw new NotFoundException();

        var dto = _mapper.Map<ShopGetDto>(shop);

        return dto;
    }

    public async Task<ShopPageDto> GetFileteredShopsAsync(int countryId, int categoryId, int page , LanguageType language = LanguageType.Azerbaijan)
    {
        var countries = _countryService.GetAll(language);
        var categories = _categoryService.GetAll(language);

        var query = _repository.GetAll(include: _getWithIncludes());

        if(countryId != 0)
        {
            if (!(await _countryService.IsExistAsync(countryId)))
                throw new NotFoundException();

            query = query.Where(x => x.CountryId == countryId);
        }

        if (categoryId != 0)
        {
            if (!(await _categoryService.IsExistAsync(categoryId)))
                throw new NotFoundException();

            query = query.Where(x => x.ShopCategories.Any(x => x.CategoryId == categoryId));
        }
        var count = query.Count();

        var pageCount = (int)Math.Ceiling((decimal)count / 2);

        if (page > pageCount)
            page = pageCount;

        if (page < 1)
            page = 1;

        query = _repository.Paginate(query, 2, page);

        var shops =  await query.ToListAsync();
        
        var dtos = _mapper.Map<List<ShopGetDto>>(shops);

        ShopPageDto paginateDto = new()
        {
            Countries = countries,
            Categories = categories,
            Shops = dtos,
            PageCount = pageCount,
            CurrentPage = page
        };
       
        return paginateDto;
    }
}
