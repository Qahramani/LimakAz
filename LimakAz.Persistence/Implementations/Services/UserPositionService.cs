using LimakAz.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace LimakAz.Persistence.Implementations.Services;

internal class UserPositionService : IUserPositionService
{
    private readonly IUserPositionRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILanguageService _languageService;

    public UserPositionService(IUserPositionRepository repository, IMapper mapper, ILanguageService languageService)
    {
        _repository = repository;
        _mapper = mapper;
        _languageService = languageService;
    }

    public List<UserPositionGetDto> GetAllAsync(LanguageType language = LanguageType.Azerbaijan)
    {
        var userPositions = _repository.GetAll(include: x => x.Include(x => x.UserPositionDetails.Where(x => x.LanguageId == (int)language)));

        var dtos = _mapper.Map<List<UserPositionGetDto>>(userPositions);

        return dtos;
    }
}