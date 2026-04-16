using MediatR;

public class DeleteUnitHandler : IRequestHandler<DeleteUnitCommand>
{
    private readonly IUnitRepository _repository;

    public DeleteUnitHandler(IUnitRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
    {
        var unit = await _repository.GetByIdAsync(request.Id);

        if (unit is null)
            throw new Exception("Unit não encontrada");

        await _repository.DeleteAsync(unit);
    }
}