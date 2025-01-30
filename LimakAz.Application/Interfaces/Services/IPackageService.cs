namespace LimakAz.Application.Interfaces.Services;

public interface IPackageService
{
     Task<string> CreatePacakageAsync(OrderBasketDto dto);
    Task<PackageGetUiDto> GetAuthenticatedUserPackages(int statusId, LanguageType language = LanguageType.Azerbaijan);
    Task<List<PackageGetDto>> GetFilteredPackagesAsync(LanguageType language = LanguageType.Azerbaijan);
    Task CancelOrderAsync(int id);
    Task RepairOrderAsync(int id);
    Task NextOrderStatusAsync(int id);
    Task PrevOrderStatusAsync(int id);
    Task DeleteAsync(int id);
    Task<PackageGetDto> GetAsync( int id,LanguageType language = LanguageType.Azerbaijan);
    Task UpdateWeigth(int id, decimal weigth);
    Task SendNotificationEmail(int packageId);
}
