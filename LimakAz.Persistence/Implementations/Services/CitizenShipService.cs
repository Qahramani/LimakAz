using LimakAz.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace LimakAz.Persistence.Implementations.Services;

internal class CitizenShipService : ICitizenShipService
{
    private readonly ICitizenShipRepository _repository;
    private readonly IMapper _mapper;

    public CitizenShipService(ICitizenShipRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public List<CitizenShipGetDto> GetAllAsync(LanguageType language = LanguageType.Azerbaijan)
    {
        var citizenShips = _repository.GetAll(include: x => x.Include(x => x.CitizenShipDetails.Where(x => x.LanguageId == (int)language)));

        var dtos = _mapper.Map<List<CitizenShipGetDto>>(citizenShips);

        return dtos;
    }
}