using MediatR;
using StockChef.Application.DTOs.StockMovements;
using StockChef.Application.Features.StockMovements.Queries;
using StockChef.Application.Interfaces;

namespace StockChef.Application.Features.StockMovements.Handlers;

public class GetStockMovementByIdQueryHandler
    : IRequestHandler<GetStockMovementByIdQuery, StockMovementDto?>
{
    private readonly IStockMovementRepository _repository;

    public GetStockMovementByIdQueryHandler(
        IStockMovementRepository repository)
    {
        _repository = repository;
    }

    public async Task<StockMovementDto?> Handle(
        GetStockMovementByIdQuery request,
        CancellationToken cancellationToken)
    {
        var movement = await _repository.GetByIdAsync(request.Id);

        if (movement is null)
            return null;

        return new StockMovementDto
        {
            Id = movement.Id,
            ProductId = movement.ProductId,
            MovementType = movement.Type,
            Quantity = movement.Quantity,
            Reason = movement.Reason
        };
    }
}