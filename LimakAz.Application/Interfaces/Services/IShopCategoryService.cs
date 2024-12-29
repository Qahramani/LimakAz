namespace LimakAz.Application.Interfaces.Services;

public interface IShopCategoryService 
{
    Task<bool> DeleteAsync(int id);
}
