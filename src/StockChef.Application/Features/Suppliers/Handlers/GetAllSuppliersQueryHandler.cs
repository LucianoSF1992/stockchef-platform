using MediatR;
using StockChef.Application.DTOs.Suppliers;
using StockChef.Application.Features.Suppliers.Queries;
using StockChef.Application.Interfaces;

namespace StockChef.Application.Features.Suppliers.Handlers;

public class GetAllSuppliersQueryHandler
    : IRequestHandler<GetAllSuppliersQuery, IEnumerable<SupplierDto>>
{
    private readonly ISupplierRepository _repository;

    public GetAllSuppliersQueryHandler(
        ISupplierRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<SupplierDto>> Handle(
        GetAllSuppliersQuery request,
        CancellationToken cancellationToken)
    {
        var suppliers = await _repository.GetAllAsync();

        return suppliers.Select(supplier => new SupplierDto
        {
            Id = supplier.Id,
            Name = supplier.Name,
            TradeName = supplier.TradeName,
            Cnpj = supplier.Cnpj,
            Email = supplier.Email,
            Phone = supplier.Phone,
            ContactPerson = supplier.ContactPerson
        });
    }
}