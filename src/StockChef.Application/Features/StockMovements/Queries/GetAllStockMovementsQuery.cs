using MediatR;
using StockChef.Application.DTOs.StockMovements;

namespace StockChef.Application.Features.StockMovements.Queries;

public record GetAllStockMovementsQuery()
    : IRequest<IEnumerable<StockMovementDto>>;