using Microsoft.EntityFrameworkCore;

namespace LimakAz.Persistence.Implementations.Services;

internal class SettingService : ISettingService
{
    private readonly ISettingRepository _repository;
    private readonly IMapper _mapper;

    public SettingService(ISettingRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<SettingGetDto>> GettAllAsync()
    {
        var settings =  _repository.GetAll(include : x => x.Include(x => x.SettingDetails));

        var dtos = _mapper.Map<List<SettingGetDto>>(settings);

        return dtos;
    }

    public async Task<SettingUpdateDto> GetUpdateDtoAsync(int id)
    {
        var setting = await _repository.GetAsync(x => x.Id == id, x => x.Include(x => x.SettingDetails));

        if (setting == null)
            throw new NotFoundException();

        var dto = _mapper.Map<SettingUpdateDto>(setting);

        return dto;
    }
}
