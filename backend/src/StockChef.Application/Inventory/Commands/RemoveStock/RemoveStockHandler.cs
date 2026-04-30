public class RemoveStockHandler : IRequestHandler<RemoveStockCommand, Unit>
{
    private readonly IInventoryRepository _repository;

    public RemoveStockHandler(IInventoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(RemoveStockCommand request, CancellationToken cancellationToken)
    {
        var inventory = await _repository.GetByProductAndUnitAsync(request.ProductId, request.UnitId);

        if (inventory is null)
            throw new Exception("Estoque não encontrado");

        inventory.RemoveStock(request.Quantity);

        await _repository.UpdateAsync(inventory);

        return Unit.Value;
    }
}