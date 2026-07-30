using MediatR;
using StockChef.Application.DTOs.Suppliers;

namespace StockChef.Application.Features.Suppliers.Commands;

public record CreateSupplierCommand(
    CreateSupplierDto Supplier)
    : IRequest<Guid>;