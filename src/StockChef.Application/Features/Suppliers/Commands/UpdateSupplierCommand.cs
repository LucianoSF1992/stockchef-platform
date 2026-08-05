using MediatR;
using StockChef.Application.DTOs.Suppliers;

namespace StockChef.Application.Features.Suppliers.Commands;

public record UpdateSupplierCommand(
    Guid Id,
    UpdateSupplierDto Supplier)
    : IRequest<bool>;