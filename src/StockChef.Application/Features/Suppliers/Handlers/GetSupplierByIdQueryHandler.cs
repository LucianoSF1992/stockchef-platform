using MediatR;
using StockChef.Application.DTOs.Suppliers;
using StockChef.Application.Features.Suppliers.Queries;
using StockChef.Application.Interfaces;

namespace StockChef.Application.Features.Suppliers.Handlers;

public class GetSupplierByIdQueryHandler
    : IRequestHandler<GetSupplierByIdQuery, SupplierDto?>
{
    private readonly ISupplierRepository _repository;

    public GetSupplierByIdQueryHandler(
        ISupplierRepository repository)
    {
        _repository = repository;
    }

    public async Task<SupplierDto?> Handle(
        GetSupplierByIdQuery request,
        CancellationToken cancellationToken)
    {
        var supplier = await _repository.GetByIdAsync(request.Id);

        if (supplier is null)
            return null;

        return new SupplierDto
        {
            Id = supplier.Id,
            Name = supplier.Name,
            TradeName = supplier.TradeName,
            Cnpj = supplier.Cnpj,
            Email = supplier.Email,
            Phone = supplier.Phone,
            ContactPerson = supplier.ContactPerson
        };
    }
}