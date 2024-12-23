using LimakAz.Application.DTOs.LanguageDtos;
using LimakAz.Application.Interfaces.Services.Generic;
using System.Linq.Expressions;

namespace LimakAz.Application.Interfaces.Services;

public interface ILanguageService : IGetService<LanguageGetDto>
{
    Task<LanguageGetDto> GetLanguageAsync(Expression<Func<Language, bool>> predicate);
}
