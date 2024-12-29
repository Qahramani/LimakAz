namespace LimakAz.Persistence.Implementations.Services;

internal class ShopCategoryService : IShopCategoryService 
{
    private readonly IShopCategoryRepository _repository;
    private readonly IMapper _mapper;

    public ShopCategoryService(IShopCategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _repository.GetAsync(id);

        if (item == null)
            throw new NotFoundException();

         _repository.HardDelete(item);

        await _repository.SaveChangesAsync();

        return true;
    }
}
