namespace LimakAz.Application.Interfaces.Services.UI;

public interface IBasketService 
{
    Task<List<BasketItemGetDto>> GetBasketByCountry(int countryId);
}
