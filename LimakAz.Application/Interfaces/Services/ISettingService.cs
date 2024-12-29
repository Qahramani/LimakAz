using LimakAz.Application.DTOs.LanguageDtos;
using LimakAz.Application.Interfaces.Services.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LimakAz.Application.Interfaces.Services;

public interface ISettingService : IGetService<SettingGetDto>
{
    Task<bool> UpdateAsync(SettingUpdateDto  dto, ModelStateDictionary ModelState);
    Task<SettingUpdateDto> GetUpdatedDtoAsync(int id);
    Task<Dictionary<string, string>> GetSettingDictionaryAsync(int languageId);

}
