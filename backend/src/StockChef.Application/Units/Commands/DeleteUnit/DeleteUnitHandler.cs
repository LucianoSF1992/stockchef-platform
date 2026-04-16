using MediatR;

public class DeleteUnitHandler : IRequestHandler<DeleteUnitCommand, Unit>
{
    private readonly IUnitRepository _repository;

    public DeleteUnitHandler(IUnitRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
    {
        var unit = await _repository.GetByIdAsync(request.Id);

        if (unit is null)
            throw new KeyNotFoundException("Unit não encontrada");

        await _repository.DeleteAsync(unit);

        return Unit.Value;
    }
}