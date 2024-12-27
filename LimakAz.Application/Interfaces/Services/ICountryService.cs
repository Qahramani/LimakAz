using LimakAz.Application.Interfaces.Services.Generic;

namespace LimakAz.Application.Interfaces.Services;

public interface ICountryService : IGetService<CountryGetDto>, IModifyService<CountryCreateDto,CountryUpdateDto>
{
    Task<CountryGetDto?> GetAsync(int Id);
}
