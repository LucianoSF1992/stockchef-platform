using MediatR;

namespace StockChef.Application.Features.Products.Commands;

public record DeleteProductCommand(Guid Id) : IRequest<bool>;