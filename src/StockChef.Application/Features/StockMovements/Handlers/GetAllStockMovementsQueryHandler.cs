using MediatR;
using StockChef.Application.DTOs.StockMovements;
using StockChef.Application.Features.StockMovements.Queries;
using StockChef.Application.Interfaces;

namespace StockChef.Application.Features.StockMovements.Handlers;

public class GetAllStockMovementsQueryHandler
    : IRequestHandler<GetAllStockMovementsQuery, IEnumerable<StockMovementDto>>
{
    private readonly IStockMovementRepository _repository;

    public GetAllStockMovementsQueryHandler(
        IStockMovementRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<StockMovementDto>> Handle(
        GetAllStockMovementsQuery request,
        CancellationToken cancellationToken)
    {
        var movements = await _repository.GetAllAsync();

        return movements.Select(movement => new StockMovementDto
        {
            Id = movement.Id,
            ProductId = movement.ProductId,
            MovementType = movement.Type,
            Quantity = movement.Quantity,
            Reason = movement.Reason
        });
    }
}