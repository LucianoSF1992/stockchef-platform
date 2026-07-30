using MediatR;
using StockChef.Application.Features.Suppliers.Commands;
using StockChef.Application.Interfaces;
using StockChef.Domain.Entities;

namespace StockChef.Application.Features.Suppliers.Handlers;

public class CreateSupplierCommandHandler
    : IRequestHandler<CreateSupplierCommand, Guid>
{
    private readonly ISupplierRepository _repository;

    public CreateSupplierCommandHandler(
        ISupplierRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(
        CreateSupplierCommand request,
        CancellationToken cancellationToken)
    {
        var dto = request.Supplier;

        var supplier = new Supplier(
            dto.Name,
            dto.Cnpj,
            dto.TradeName,
            dto.Email,
            dto.Phone,
            dto.ContactPerson
        );

        await _repository.AddAsync(supplier);

        return supplier.Id;
    }
}