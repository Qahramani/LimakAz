using LimakAz.Application.Interfaces.Services.External;
using LimakAz.Application.Interfaces.Services.UI;
using LimakAz.Domain.Enums;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Runtime.CompilerServices;

namespace LimakAz.Persistence.Implementations.Services.UI;

internal class CalculatorService : ICalculatorService
{
    private readonly ICountryService _countryService;
    private readonly ILocalPointService _localPointService;
    private readonly IMapper _mapper;
    private readonly ITariffService _tariffService;
    private readonly ICurrencyService _currencyService;
    public CalculatorService(ICountryService countryService, ILocalPointService localPointService, IMapper mapper, ITariffService tariffService, ICurrencyService currencyService)
    {
        _countryService = countryService;
        _localPointService = localPointService;
        _mapper = mapper;
        _tariffService = tariffService;
        _currencyService = currencyService;
    }

    public async Task<CalculatorDto> CalculateAsync(CalculatorDto dto, LanguageType language = LanguageType.Azerbaijan)
    {
        var calculatorDto = GetCalculatorDto(language);
        dto.Countries = calculatorDto.Countries;
        dto.LocalPoints = calculatorDto.LocalPoints;

        decimal liquidFee = (int)dto.MatterType == 2 ? 2 : 0;

        var tariffs = await _tariffService.GetTariffsByCountry(dto.CountryId);


        decimal weigth = dto.Weight;
        if (dto.Width >= 60 || dto.Lenght >= 60 || dto.Height >= 60)
        {
            decimal volumetricWeight = (dto.Width * dto.Height * dto.Lenght) / 6000;

            weigth = Math.Max(volumetricWeight, dto.Weight);
        }

        decimal totalAmount;

        if (weigth > tariffs.Max(x => x.MaxValue))
        {
            totalAmount = (weigth * tariffs.Max(x => x.Price) + liquidFee) * dto.Count;
        }
        else
        {
            var price = tariffs.FirstOrDefault(x => x.MinValue <= weigth && x.MaxValue >= weigth) != null ? tariffs.FirstOrDefault(x => x.MinValue <= weigth && x.MaxValue >= weigth)!.Price : tariffs.Max(x => x.Price);

            totalAmount = (price + liquidFee) * dto.Count;
        }

        var usdCoefficient = await _currencyService.GetCurrencyCoefficientAsync("USD");

        dto.TotalPriceInAzn = Math.Round(totalAmount,2);
        dto.TotalPriceInUsd = Math.Round(totalAmount / usdCoefficient, 2);

        return dto;
    }

    public CalculatorDto GetCalculatorDto(LanguageType language = LanguageType.Azerbaijan)
    {
        var countries = _countryService.GetAll(language);
        var localPoints = _localPointService.GetAll(language);

        var countyDtos = _mapper.Map<List<CountryGetDto>>(countries);
        var localDtos = _mapper.Map<List<LocalPointGetDto>>(localPoints);

        CalculatorDto dto = new()
        {
            Countries = countries,
            LocalPoints = localPoints,
        };

        return dto;
    }
}
