using LimakAz.Application.DTOs.LanguageDtos;
using LimakAz.Application.Interfaces.Services.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LimakAz.Application.Interfaces.Services;

public interface ISettingService : IGetService<SettingGetDto>, IModifyService<SettingCreateDto,SettingUpdateDto>
{
    //Task<SettingUpdateDto> GetUpdateDtoAsync(int id);
    //Task<bool> UpdateAsync(SettingUpdateDto dto, ModelStateDictionary ModelState);
    Task<Dictionary<string, string>> GetSettingDictionaryAsync(int languageId);

}
