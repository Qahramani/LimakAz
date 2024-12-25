using LimakAz.Application.DTOs.LanguageDtos;
using LimakAz.Domain.Enums;
using System.Linq.Expressions;

namespace LimakAz.Persistence.Implementations.Services;


internal class LanguageService : ILanguageService
{
    private readonly ILanguageRepository _repository;
    private readonly IMapper _mapper;

    public LanguageService(ILanguageRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public List<LanguageGetDto> GetAll()
    {
        var languages =  _repository.GetAll();

        var dtos = _mapper.Map<List<LanguageGetDto>>(languages);

        return dtos;
    }

    //public async Task<LanguageGetDto> GetAsync(int id)
    //{
    //    var language = await _repository.GetAsync(id);

    //    var dto = _mapper.Map<LanguageGetDto>(language);

    //    return dto;
    //}

    public async Task<LanguageGetDto> GetLanguageAsync(Expression<Func<Language, bool>> predicate)
    {
        var language = await _repository.GetAsync(predicate);

        var dto = _mapper.Map<LanguageGetDto>(language);

        return dto;
    }

}
