public class GetUnitByIdHandler : IRequestHandler<GetUnitByIdQuery, UnitDto>
{
    private readonly IUnitRepository _repository;

    public GetUnitByIdHandler(IUnitRepository repository)
    {
        _repository = repository;
    }

    public async Task<UnitDto> Handle(GetUnitByIdQuery request, CancellationToken cancellationToken)
    {
        var unit = await _repository.GetByIdAsync(request.Id);

        return new UnitDto
        {
            Id = unit.Id,
            Name = unit.Name
        };
    }
}