using LimakAz.Application.DTOs.LanguageDtos;
using LimakAz.Application.Interfaces.Services.Generic;
using System.Linq.Expressions;

namespace LimakAz.Application.Interfaces.Services;

public interface ILanguageService 
{
    Task<LanguageGetDto> GetLanguageAsync(Expression<Func<Language, bool>> predicate);
    List<LanguageGetDto> GetAll();
}
