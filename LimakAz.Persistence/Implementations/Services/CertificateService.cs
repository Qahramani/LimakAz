
using Azure.Core;
using LimakAz.Domain.Enums;
using LimakAz.Persistence.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace LimakAz.Persistence.Implementations.Services;


internal class CertificateService : ICertificateService
{
    private readonly ICertificateRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;

    public CertificateService(ICertificateRepository repository, IMapper mapper, ICloudinaryService cloudinaryService)
    {
        _repository = repository;
        _mapper = mapper;
        _cloudinaryService = cloudinaryService;
    }

    public async Task<bool> CreateAsync(CertificateCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        if (!dto.ImageFile.CheckSize())
        {
            ModelState.AddModelError("", "");
            return false;
        }
        if (!dto.ImageFile.CheckType())
        {
            ModelState.AddModelError("", "");
            return false;
        }

        var imagePath = await _cloudinaryService.FileCreateAsync(dto.ImageFile);

        dto.ImagePath = imagePath;

        var certificate = _mapper.Map<Certificate>(dto);

        await _repository.CreateAsync(certificate);

        await _repository.SaveChangesAsync();

        return true;
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public List<CertificateGetDto> GetAll()
    {
       var certificates = _repository.GetAll();

        var dtos = _mapper.Map<List<CertificateGetDto>>(certificates);

        return dtos;
    }

    public async Task<PaginateDto<CertificateGetDto>> GetPages(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10)
    {
        var query = _repository.GetAll();

        var count = query.Count();

        var pageCount = (int)Math.Ceiling((decimal)count / limit);

        if (page > pageCount)
            page = pageCount;

        if (page < 1)
            page = 1;

        query = _repository.Paginate(query, limit ,page);

        var certificates = await query.ToListAsync();  
        
        var dtos = _mapper.Map<List<CertificateGetDto>>(certificates);

        PaginateDto<CertificateGetDto> paginateDto = new()
        {
            Items = dtos,
            CurrentPage = page,
            PageCount = pageCount
        };

        return paginateDto;

    }

    public Task<CertificateUpdateDto> GetUpdatedDtoAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(CertificateUpdateDto dto, ModelStateDictionary ModelState)
    {
        throw new NotImplementedException();
    }
}
