using LimakAz.Application.DTOs.ContentDtos;
using LimakAz.Application.Interfaces.Services.Generic;

namespace LimakAz.Application.Interfaces.Services;

public interface IContentService : IGetService<ContentGetDto>,IModifyService<ContentCreateDto,ContentUpdateDto>
{
}
