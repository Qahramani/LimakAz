using LimakAz.Application.DTOs.LanguageDtos;
using System.Linq.Expressions;

namespace LimakAz.Application.Interfaces.Services;

public interface ILanguageService
{
    List<LanguageGetDto> GetLanguagesAsync();
    Task<LanguageGetDto> GetLanguageAsync(Expression<Func<Language, bool>> predicate);
}
