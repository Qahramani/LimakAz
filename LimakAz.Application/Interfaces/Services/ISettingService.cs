using LimakAz.Application.DTOs.LanguageDtos;

namespace LimakAz.Application.Interfaces.Services;

public interface ISettingService
{
    Task<SettingUpdateDto> GetUpdateDtoAsync(int id);
    Task<List<SettingGetDto>> GettAllAsync();
}
