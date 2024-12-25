namespace LimakAz.Application.Interfaces.Services.Generic;

public interface IGetService<TGetDto>
where TGetDto : IDto
{
   // Task<TGetDto> GetAsync(int id);
    List<TGetDto> GetAll();
    Task<PaginateDto<TGetDto>> GetPages(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10);
}