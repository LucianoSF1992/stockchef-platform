using MediatR;
using StockChef.Application.Features.Suppliers.Commands;
using StockChef.Application.Interfaces;

namespace StockChef.Application.Features.Suppliers.Handlers;

public class UpdateSupplierCommandHandler
    : IRequestHandler<UpdateSupplierCommand, bool>
{
    private readonly ISupplierRepository _repository;

    public UpdateSupplierCommandHandler(
        ISupplierRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        UpdateSupplierCommand request,
        CancellationToken cancellationToken)
    {
        var supplier = await _repository.GetByIdAsync(request.Id);

        if (supplier is null)
            return false;

        supplier.Update(
            request.Supplier.Name,
            request.Supplier.Cnpj,
            request.Supplier.TradeName,
            request.Supplier.Email,
            request.Supplier.Phone,
            request.Supplier.ContactPerson);

        await _repository.UpdateAsync(supplier);

        return true;
    }
}