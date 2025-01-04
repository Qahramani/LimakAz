using LimakAz.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace LimakAz.Persistence.Implementations.Services;

internal class GenderService : IGenderService
{
    private readonly IGenderRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILanguageService _languageService;

    public GenderService(IGenderRepository repository, IMapper mapper, ILanguageService languageService)
    {
        _repository = repository;
        _mapper = mapper;
        _languageService = languageService;
    }

    public List<GenderGetDto> GetAllAsync(LanguageType language = LanguageType.Azerbaijan)
    {
        var genders = _repository.GetAll(include: x => x.Include(x => x.GenderDetails.Where(x => x.LanguageId == (int)language)));

        var dtos = _mapper.Map<List<GenderGetDto>>(genders);

        return dtos;
    }
}
