﻿using LimakAz.Application.DTOs.LanguageDtos;

namespace LimakAz.Application.Interfaces.Services;

public interface ICookieService
{
    Task<LanguageGetDto> GetSelectedLanguageAsync();
    Task<LanguageType> GetSelectedLanguageTypeAsync();
    bool IsAuthorized();
    string GetUserId();
}
