using LimakAz.Application.DTOs;
using LimakAz.Application.Exceptions;
using LimakAz.Application.Interfaces.Services.External;
using System.Xml.Serialization;

namespace LimakAz.Infrastructure.Services;

public class CurrencyService : ICurrencyService
{
    private readonly HttpClient _httpClient;
    private const string _currencyBasePath = "https://www.cbar.az/currencies/";

    public CurrencyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<decimal> GetCurrencyCoefficientAsync(string code)
    {
        if (code.ToLower() == "azn") return 1;

        var url = $"{_currencyBasePath}{DateTime.Now.ToString("dd.MM.yyyy")}.xml";


        var response = await _httpClient.GetStringAsync(url);

        XmlSerializer serializer = new XmlSerializer(typeof(ValCurs));
        ValCurs valCurs = new();

        using (StringReader reader = new StringReader(response))
        {
            valCurs = (ValCurs)serializer.Deserialize(reader)!;
        }

        var currencies = valCurs?.ValType.FirstOrDefault(x => x.Type == "Xarici valyutalar");

        var selectedCurrency = currencies?.Valute.FirstOrDefault(x => x.Code.Equals(code, StringComparison.CurrentCultureIgnoreCase));

        return (decimal)(selectedCurrency?.Value ?? 1);
    }

    public async Task<Dictionary<string,decimal>> GetExchangeRatesAsync()
    {
        var url = $"{_currencyBasePath}{DateTime.Now.ToString("dd.MM.yyyy")}.xml";

        var response = await _httpClient.GetStringAsync(url);

        XmlSerializer serializer = new XmlSerializer(typeof(ValCurs));

        using(StringReader reader = new StringReader(response))
        {
            ValCurs valCurs = (ValCurs)serializer.Deserialize(reader)!;

            var rates = new Dictionary<string,decimal>();

            var currencies = valCurs?.ValType.FirstOrDefault(x => x.Type == "Xarici valyutalar");
             
            rates.Add("AZN",1);

            foreach (var valute in currencies!.Valute)
            {
                rates.Add(valute.Code,(decimal)valute.Value);
            }

            return rates;   
        }
    }

    public async Task<decimal> ConvertAsync(decimal amount, string from, string to)
    {
        var rates = await GetExchangeRatesAsync();

        if (!rates.ContainsKey(from) || !rates.ContainsKey(to))
            throw new InvalidRateExchangeException();

        decimal inputInAzn = rates[from] * amount;
        decimal toRate = rates[to];
        decimal convertedAmount = inputInAzn / toRate;

        return Math.Round(convertedAmount,5);
    }
}
