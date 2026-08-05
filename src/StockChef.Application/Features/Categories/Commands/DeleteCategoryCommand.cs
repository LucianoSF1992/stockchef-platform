using MediatR;

namespace StockChef.Application.Features.Categories.Commands;

public record DeleteCategoryCommand(Guid Id)
    : IRequest<bool>;