using MediatR;

public class UpdateUnitHandler : IRequestHandler<UpdateUnitCommand, Unit>
{
    private readonly IUnitRepository _repository;

    public UpdateUnitHandler(IUnitRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
    {
        var unit = await _repository.GetByIdAsync(request.Id);

        if (unit is null)
            throw new Exception("Unit não encontrada");

        unit.Name = request.Name;

        await _repository.UpdateAsync(unit);

        return Unit.Value;
    }
}