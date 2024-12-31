using LimakAz.Domain.Enums;
using LimakAz.Persistence.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace LimakAz.Persistence.Implementations.Services;

internal class SliderService : ISliderService
{
    private readonly ISliderRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;

    public SliderService(ISliderRepository repository, IMapper mapper, ICloudinaryService cloudinaryService)
    {
        _repository = repository;
        _mapper = mapper;
        _cloudinaryService = cloudinaryService;
    }

    public async Task<bool> CreateAsync(SliderCreateDto dto, ModelStateDictionary ModelState)
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

        var imagePath = await _cloudinaryService.FileCreateAsync(dto.ImageFile!);

        dto.ImagePath = imagePath;

        var slider = _mapper.Map<Slider>(dto);

        await _repository.CreateAsync(slider);

        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var slider = await _repository.GetAsync(id);

        if (slider == null)
            throw new NotFoundException();

        _repository.HardDelete(slider);

        await _repository.SaveChangesAsync();
    }

    public List<SliderGetDto> GetAll(LanguageType language = LanguageType.Azerbaijan)
    {
        var sliders = _repository.GetAll();

        var dtos = _mapper.Map<List<SliderGetDto>>(sliders);

        return dtos;
    }

    public async Task<SliderGetDto> GetAsync(int id, LanguageType language = LanguageType.Azerbaijan)
    {
        var slider = await _repository.GetAsync(id);

        if (slider == null)
            throw new NotFoundException();

        var dto = _mapper.Map<SliderGetDto>(slider);

        return dto; 
    }

    public async  Task<PaginateDto<SliderGetDto>> GetPagesAsync(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10)
    {
        var query = _repository.GetAll();

        var count = query.Count();

        var pageCount = (int)Math.Ceiling((decimal)count / limit);

        if (page > pageCount)
            page = pageCount;

        if (page < 1)
            page = 1;

        query = _repository.Paginate(query, limit, page);

        var sliders = await query.ToListAsync();

        var dtos = _mapper.Map<List<SliderGetDto>>(sliders);

        PaginateDto<SliderGetDto> paginateDto = new()
        {
            Items = dtos,
            CurrentPage = page,
            PageCount = pageCount
        };

        return paginateDto;
    }

    public async Task<SliderUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var slider = await _repository.GetAsync(id);

        if (slider == null)
            throw new NotFoundException();

        var dto = _mapper.Map<SliderUpdateDto>(slider);

        return dto;
    }

    public async Task<bool> IsExistAsync(int id)
    {
        return await _repository.IsExistAsync(x => x.Id == id);
    }

    public async Task<bool> UpdateAsync(SliderUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (dto.ImageFile == null)
            return true;

        var slider = await _repository.GetAsync(dto.Id);
        
        if(slider == null)
            throw new NotFoundException();

        await _cloudinaryService.FileDeleteAsync(slider.ImagePath);

        slider.ImagePath = await _cloudinaryService.FileCreateAsync(dto.ImageFile);

        _repository.Update(slider);

        await _repository.SaveChangesAsync();

        return true;
    }
}
