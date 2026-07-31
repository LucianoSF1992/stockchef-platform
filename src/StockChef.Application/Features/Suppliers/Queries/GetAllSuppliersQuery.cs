using MediatR;
using StockChef.Application.DTOs.Suppliers;

namespace StockChef.Application.Features.Suppliers.Queries;

public record GetAllSuppliersQuery()
    : IRequest<IEnumerable<SupplierDto>>;