namespace LimakAz.Application.Interfaces.Services;

public interface IPackageService
{
     Task<string> CreatePacakageAsync(OrderBasketDto dto);
    Task<PackageGetUserDto> GetAuthenticatedUserPackages(int statusId, LanguageType language = LanguageType.Azerbaijan);
    Task<PackageGetAdminDto> GetFilteredPackagesAsync(int statusId = 0,LanguageType language = LanguageType.Azerbaijan);
    Task CancelPackageAsync(int id);
    Task RepairPackageAsync(int id);
    Task NextOrderStatusAsync(int id);
    Task PrevOrderStatusAsync(int id);
    Task DeleteAsync(int id);
    Task FinishOrderAsync(int id);
    Task<PackageGetDto> GetAsync( int id,LanguageType language = LanguageType.Azerbaijan);
    Task UpdateWeigth(int id, decimal weigth);
    Task SendNotificationEmail(int packageId);
}
