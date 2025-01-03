using LimakAz.Application.AutoMappers;
using LimakAz.Application.Interfaces.Services.Generic;

namespace LimakAz.Application.Interfaces.Services;

public interface IContentService : IGetService<ContentGetDto>,IModifyService<ContentCreateDto,ContentUpdateDto>
{
    List<ContentGetDto> GetByPageType(PageType pageType, LanguageType language = LanguageType.Azerbaijan);
}
