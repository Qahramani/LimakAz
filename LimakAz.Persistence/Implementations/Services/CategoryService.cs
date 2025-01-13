
using LimakAz.Application.Interfaces.Services.External;
using LimakAz.Domain.Enums;
using LimakAz.Persistence.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace LimakAz.Persistence.Implementations.Services;

internal class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILanguageService _languageService;
    private readonly ICloudinaryService _cloudinaryService;

    public CategoryService(ICategoryRepository repository, IMapper mapper, ILanguageService languageService, ICloudinaryService cloudinaryService)
    {
        _repository = repository;
        _mapper = mapper;
        _languageService = languageService;
        _cloudinaryService = cloudinaryService;
    }

    public async Task<bool> CreateAsync(CategoryCreateDto dto, ModelStateDictionary ModelState)
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

        var existingCategoryName = await _repository.GetAsync(x => x.CategoryDetails.FirstOrDefault()!.Name.ToLower() == dto.CategoryDetails.FirstOrDefault()!.Name!.ToLower());

        if (existingCategoryName != null)
        {
            ModelState.AddModelError("", "Bu adda kategoriya mövcuddur");
            return false;
        }


        foreach (var detail in dto.CategoryDetails)
        {
            var existLanguage = await _languageService.GetLanguageAsync(x => x.Id == detail.LanguageId);

            if (existLanguage == null)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }
        }

        var imagePath = await _cloudinaryService.FileCreateAsync(dto.ImageFile!);

        dto.LogoPath = imagePath;

        var category = _mapper.Map<Category>(dto);

        await _repository.CreateAsync(category);

        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _repository.GetAsync(id);

        if (category == null)
            throw new NotFoundException();

        _repository.SoftDelete(category);

        await _repository.SaveChangesAsync();
    }

    public List<CategoryGetDto> GetAll(LanguageType language = LanguageType.Azerbaijan)
    {
        var categories = _repository.GetAll(include: _getWithIncludes(language));

        var dtos = _mapper.Map<List<CategoryGetDto>>(categories);

        return dtos;
    }



    public async Task<PaginateDto<CategoryGetDto>> GetPagesAsync(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10)
    {
        var query = _repository.GetAll(include: _getWithIncludes(language));

        var count = query.Count();

        var pageCount = (int)Math.Ceiling((decimal)count / limit);

        if (page > pageCount)
            page = pageCount;

        if (page < 1)
            page = 1;

        query = _repository.Paginate(query, limit, page);


        var categories = await query.ToListAsync();

        var dtos = _mapper.Map<List<CategoryGetDto>>(categories);

        PaginateDto<CategoryGetDto> paginateDto = new()
        {
            Items = dtos,
            CurrentPage = page,
            PageCount = pageCount
        };

        return paginateDto;
    }

    public async Task<CategoryUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var category = await _repository.GetAsync(x => x.Id == id, _getWithIncludes());

        if (category == null)
            throw new NotFoundException();

        var dto = _mapper.Map<CategoryUpdateDto>(category);

        return dto;
    }

    public async Task<bool> UpdateAsync(CategoryUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var category = await _repository.GetAsync(x => x.Id == dto.Id, x => x.Include(x => x.CategoryDetails));

        if (category == null)
            throw new NotFoundException();

        var existingCategoryName = await _repository.GetAsync(x => x.CategoryDetails.FirstOrDefault()!.Name.ToLower() == dto.CategoryDetails.FirstOrDefault()!.Name!.ToLower() && x.Id != dto.Id);

        if (existingCategoryName != null)
        {
            ModelState.AddModelError("", "Bu adda kategoriya mövcuddur");
            return false;
        }

        foreach (var detail in dto.CategoryDetails)
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
                ModelState.AddModelError("", "Doğru şəkil formatı daxil edin");
                return false;
            }

            await _cloudinaryService.FileDeleteAsync(category.LogoPath);

            var imagePath = await _cloudinaryService.FileCreateAsync(dto.ImageFile);

            category.LogoPath = imagePath;
        }
        category = _mapper.Map(dto, category);

        _repository.Update(category);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task<CategoryGetDto> GetAsync(int id, LanguageType language = LanguageType.Azerbaijan)
    {
        var category = await _repository.GetAsync(x => x.Id == id, _getWithIncludes());

        if (category == null)
            throw new NotFoundException();

        var dto = _mapper.Map<CategoryGetDto>(category);

        return dto;
    }

    private static Func<IQueryable<Category>, IIncludableQueryable<Category, object>> _getWithIncludes(LanguageType language)
    {
        return x => x.Include(x => x.CategoryDetails.Where(x => x.LanguageId == (int)language));
    }
    private static Func<IQueryable<Category>, IIncludableQueryable<Category, object>> _getWithIncludes()
    {
        return x => x.Include(x => x.CategoryDetails);
    }

    public async Task<bool> IsExistAsync(int id)
    {
       return await _repository.IsExistAsync(x => x.Id == id);
    }
}
