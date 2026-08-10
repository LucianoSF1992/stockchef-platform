using MediatR;
using StockChef.Application.DTOs.StockMovements;

namespace StockChef.Application.Features.StockMovements.Commands;

public record CreateStockMovementCommand(
    CreateStockMovementDto StockMovement)
    : IRequest<Guid>;