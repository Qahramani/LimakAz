using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace LimakAz.Persistence.Implementations.Services;

internal class AddressLineService : IAddressLineService
{
    private readonly IAddressLineRepository _repository;
    private readonly IMapper _mapper;

    public AddressLineService(IAddressLineRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> CreateAsync(AddressLineCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var isExist = await _repository.IsExistAsync(x => x.Key == dto.Key);

        if(isExist)
        {
            ModelState.AddModelError("Key", "Bu adda acar movcuddur");
            return false;
        }

        var line = _mapper.Map<AddressLine>(dto);

        await _repository.CreateAsync(line);

        await _repository.SaveChangesAsync();

        return true;
            
    }

    public async Task DeleteAsync(int id)
    {
        var line = await _repository.GetAsync(id);

        if (line == null)
            throw new NotFoundException();

        _repository.HardDelete(line);

        await _repository.SaveChangesAsync();
    }

    public List<AddressLineGetDto> GetAll(LanguageType language = LanguageType.Azerbaijan)
    {
        var line = _repository.GetAll();

        var dtos = _mapper.Map<List<AddressLineGetDto>>(line);

        return dtos;
    }

    public async Task<AddressLineGetDto> GetAsync(int id, LanguageType language = LanguageType.Azerbaijan)
    {
        var line = await _repository.GetAsync(id);

        if (line == null)
            throw new NotFoundException();

        var dto = _mapper.Map<AddressLineGetDto>(line);

        return dto;
    }

    public Task<Dictionary<string, string>> GetDictionaryAsync(int languageId)
    {
        var lines = _repository.GetAll().ToDictionaryAsync(x => x.Key, x=> x.Value);

        return lines;
    }

    public async Task<PaginateDto<AddressLineGetDto>> GetPagesAsync(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10)
    {
        var query = _repository.GetAll();

        var count = query.Count();

        var pageCount = (int)Math.Ceiling((decimal)count / limit);

        if (page > pageCount)
            page = pageCount;

        if (page < 1)
            page = 1;

        query = _repository.Paginate(query, limit, page);

        var warehoueses = await query.ToListAsync();

        var dtos = _mapper.Map<List<AddressLineGetDto>>(warehoueses);

        PaginateDto<AddressLineGetDto> paginateDto = new()
        {
            Items = dtos,
            CurrentPage = page,
            PageCount = pageCount
        };

        return paginateDto;
    }

    public async Task<AddressLineUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var line = await _repository.GetAsync(id);

        if (line == null)
            throw new NotFoundException();

        var dto = _mapper.Map<AddressLineUpdateDto>(line);

        return dto; 
    }

    public async Task<bool> IsExistAsync(int id)
    {
        return await _repository.IsExistAsync(x => x.Id == id);
    }

    public async Task<bool> UpdateAsync(AddressLineUpdateDto dto, ModelStateDictionary ModelState)
    {

        if (!ModelState.IsValid)
            return false;

        var isExist = await _repository.IsExistAsync(x => x.Key == dto.Key && x.Id != dto.Id);

        if (isExist)
        {
            ModelState.AddModelError("Key", "Bu adda acar movcuddur");
            return false;
        }
        var line = await _repository.GetAsync(dto.Id);

        if (line == null)
            throw new NotFoundException();

        line = _mapper.Map(dto,line);

        _repository.Update(line);

        await _repository.SaveChangesAsync();

        return true;
    }
}
