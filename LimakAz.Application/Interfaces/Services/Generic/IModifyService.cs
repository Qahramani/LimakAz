﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LimakAz.Application.Interfaces.Services.Generic;

public interface IModifyService<TCreateDto, TUpdateDto>
 where TCreateDto : IDto
 where TUpdateDto : IDto
{
    Task<bool> CreateAsync(TCreateDto dto, ModelStateDictionary ModelState);
    Task<bool> UpdateAsync(TUpdateDto dto, ModelStateDictionary ModelState);
    Task<TUpdateDto> GetUpdatedDtoAsync(int id);
    Task DeleteAsync(int id);
}
