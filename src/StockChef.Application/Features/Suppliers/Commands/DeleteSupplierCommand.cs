using MediatR;

namespace StockChef.Application.Features.Suppliers.Commands;

public record DeleteSupplierCommand(Guid Id)
    : IRequest<bool>;