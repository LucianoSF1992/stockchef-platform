using MediatR;
using StockChef.Application.DTOs.StockMovements;

namespace StockChef.Application.Features.StockMovements.Queries;

public record GetStockMovementByIdQuery(Guid Id)
    : IRequest<StockMovementDto?>;