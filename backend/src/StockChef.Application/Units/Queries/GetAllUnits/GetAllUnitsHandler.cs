public class GetAllUnitsHandler : IRequestHandler<GetAllUnitsQuery, List<UnitDto>>
{
    private readonly IUnitRepository _repository;

    public GetAllUnitsHandler(IUnitRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UnitDto>> Handle(GetAllUnitsQuery request, CancellationToken cancellationToken)
    {
        var units = await _repository.GetAllAsync();

        return units.Select(u => new UnitDto
        {
            Id = u.Id,
            Name = u.Name
        }).ToList();
    }
}