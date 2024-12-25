using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace LimakAz.Persistence.Implementations.Services;

internal class SettingService : ISettingService
{
    private readonly ISettingRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILanguageService _languageService;

    public SettingService(ISettingRepository repository, IMapper mapper, ILanguageService languageService)
    {
        _repository = repository;
        _mapper = mapper;
        _languageService = languageService;
    }

    public Task<bool> CreateAsync(SettingCreateDto dto, ModelStateDictionary ModelState)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public List<SettingGetDto> GetAll()
    {
        var settings = _repository.GetAll(include: x => x.Include(x => x.SettingDetails));

        var dtos = _mapper.Map<List<SettingGetDto>>(settings);

        return dtos;
    }

    public Task<PaginateDto<SettingGetDto>> GetPages(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10)
    {
        throw new NotImplementedException();
    }

    public Task<Dictionary<string, string>> GetSettingDictionaryAsync(int languageId)
    {
        var settings = _repository.GetAll(include: x => x.Include(x => x.SettingDetails.Where(x => x.LanguageId == languageId)))
                                 .ToDictionaryAsync(x => x.Key, x => x.SettingDetails.FirstOrDefault()?.Value ?? "");

        return settings;
    }

    public async Task<SettingUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var setting = await  _repository.GetAsync(x => x.Id == id, x => x.Include(x => x.SettingDetails));

        if (setting == null)
            throw new NotFoundException();

        var dto = _mapper.Map<SettingUpdateDto>(setting);

        return dto;
    }

    public async Task<bool> UpdateAsync(SettingUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;



        var setting = await _repository.GetAsync(x => x.Id == dto.Id, x => x.Include(x=> x.SettingDetails));

        if (setting == null)
            throw new NotFoundException("tapilmadi");

        foreach (var detail in dto.SettingDetails)
        {
            var existLanguage = await _languageService.GetLanguageAsync(x => x.Id == detail.LanguageId);

            if (existLanguage == null)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }
        }

        setting = _mapper.Map(dto, setting);

        _repository.Update(setting);
        await _repository.SaveChangesAsync();

        return true;

    }
}
