using LimakAz.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace LimakAz.Application.Interfaces.Services.Generic;

public interface IGetService<TGetDto>
where TGetDto : IDto
{
    Task<TGetDto> GetAsync(int id, LanguageType language = LanguageType.Azerbaijan);
    List<TGetDto> GetAll(LanguageType language = LanguageType.Azerbaijan);
    Task<PaginateDto<TGetDto>> GetPagesAsync(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10);
    Task<bool> IsExistAsync(int id);
}