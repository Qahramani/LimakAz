﻿namespace LimakAz.Application.Interfaces.Services.Generic;

public interface IGetService<TGetDto>
where TGetDto : IDto
{
   // Task<TGetDto> GetAsync(int id);
    Task<List<TGetDto>> GetAllAsync();
}