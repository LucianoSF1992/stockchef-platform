using MediatR;
using UnitMediatR = MediatR.Unit;

public class DeleteUnitHandler : IRequestHandler<DeleteUnitCommand, UnitMediatR>
{
    private readonly IUnitRepository _repository;

    public DeleteUnitHandler(IUnitRepository repository)
    {
        _repository = repository;
    }

    public async Task<UnitMediatR> Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
    {
        var unit = await _repository.GetByIdAsync(request.Id);

        if (unit is null)
            throw new KeyNotFoundException("Unit não encontrada");

        await _repository.DeleteAsync(unit);

        return UnitMediatR.Value;
    }
}