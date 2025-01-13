using LimakAz.Application.Interfaces.Services.Generic;

namespace LimakAz.Application.Interfaces.Services;

public interface INewsService : IGetService<NewsGetDto>, IModifyService<NewsCreateDto,NewsUpdateDto>
{
    Task<NewsDetailsUiDto> GetNewsDetailsUiAsync(int id, LanguageType language = LanguageType.Azerbaijan);
}
