using LimakAz.Application.Interfaces.Services.UI;

namespace LimakAz.Persistence.Implementations.Services.UI;

internal class BasketService : IBasketService
{
    private readonly ICountryService _countryService;
    private readonly IAuthService _authService;

    public BasketService(ICountryService countryService, IAuthService authService)
    {
        _countryService = countryService;
        _authService = authService;
    }

    public async Task<List<BasketItemGetDto>> GetBasketByCountry(int countryId)
    {
        var country = await _countryService.GetAsync(countryId);

        if (country == null)
            throw new NotFoundException("Bu idli olke tapildami");

        return null;
    }
}
