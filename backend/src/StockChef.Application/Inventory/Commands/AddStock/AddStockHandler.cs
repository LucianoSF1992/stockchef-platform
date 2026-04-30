public class AddStockHandler : IRequestHandler<AddStockCommand, Unit>
{
    private readonly IInventoryRepository _repository;

    public AddStockHandler(IInventoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(AddStockCommand request, CancellationToken cancellationToken)
    {
        var inventory = await _repository.GetByProductAndUnitAsync(request.ProductId, request.UnitId);

        if (inventory is null)
        {
            inventory = new Inventory(
                request.ProductId,
                request.UnitId,
                request.Quantity,
                _repository.GetCompanyId()
            );

            await _repository.AddAsync(inventory);
        }
        else
        {
            inventory.AddStock(request.Quantity);
            await _repository.UpdateAsync(inventory);
        }

        return Unit.Value;
    }
}