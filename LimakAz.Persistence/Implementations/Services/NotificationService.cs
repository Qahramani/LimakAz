using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LimakAz.Persistence.Implementations.Services;

internal class NotificationService : INotificationService
{
    public Task<bool> CreateAsync(NotificationCreateDto dto, ModelStateDictionary ModelState)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public List<NotificationGetDto> GetAll(LanguageType language = LanguageType.Azerbaijan)
    {
        throw new NotImplementedException();
    }

    public Task<NotificationGetDto> GetAsync(int id, LanguageType language = LanguageType.Azerbaijan)
    {
        throw new NotImplementedException();
    }

    public Task<PaginateDto<NotificationGetDto>> GetPagesAsync(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10)
    {
        throw new NotImplementedException();
    }

    public Task<NotificationUpdateDto> GetUpdatedDtoAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsExistAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(NotificationUpdateDto dto, ModelStateDictionary ModelState)
    {
        throw new NotImplementedException();
    }
}
