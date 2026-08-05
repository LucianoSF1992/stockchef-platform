using MediatR;
using StockChef.Application.Features.Suppliers.Commands;
using StockChef.Application.Interfaces;

namespace StockChef.Application.Features.Suppliers.Handlers;

public class DeleteSupplierCommandHandler
    : IRequestHandler<DeleteSupplierCommand, bool>
{
    private readonly ISupplierRepository _repository;

    public DeleteSupplierCommandHandler(
        ISupplierRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteSupplierCommand request,
        CancellationToken cancellationToken)
    {
        var supplier = await _repository.GetByIdAsync(request.Id);

        if (supplier is null)
            return false;

        await _repository.DeleteAsync(request.Id);

        return true;
    }
}