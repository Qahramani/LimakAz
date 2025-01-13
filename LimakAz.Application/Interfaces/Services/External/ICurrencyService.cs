namespace LimakAz.Application.Interfaces.Services.External;

public interface ICurrencyService
{
    Task<decimal> GetCurrencyCoefficientAsync(string code);
    Task<Dictionary<string, decimal>> GetExchangeRatesAsync();
    Task<decimal> ConvertAsync(decimal amount, string from, string to);
}
