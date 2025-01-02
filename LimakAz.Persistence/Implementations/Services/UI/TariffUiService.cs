//using LimakAz.Application.DTOs.UIDtos;
//using LimakAz.Application.Interfaces.Services.UI;
//using LimakAz.Domain.Enums;

//namespace LimakAz.Persistence.Implementations.Services.UI;

//internal class TariffUiService : ITariffUiService
//{
//    private readonly ILocalPointService _localPointService;
//    private readonly ITariffService _tariffService;

//    public TariffUiService(ILocalPointService localPointService, ITariffService tariffService)
//    {
//        _localPointService = localPointService;
//        _tariffService = tariffService;
//    }

//    public async Task<TariffsUiDto> GetAsync(LanguageType language = LanguageType.Azerbaijan)
//    {
//        var points = _localPointService.GetAll(language);
//        var tariffs = _tariffService.
//    }
//}
