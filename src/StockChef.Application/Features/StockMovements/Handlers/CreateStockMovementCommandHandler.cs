using MediatR;
using StockChef.Application.Features.StockMovements.Commands;
using StockChef.Application.Interfaces;
using StockChef.Domain.Entities;

namespace StockChef.Application.Features.StockMovements.Handlers;

public class CreateStockMovementCommandHandler
    : IRequestHandler<CreateStockMovementCommand, Guid>
{
    private readonly IProductRepository _productRepository;
    private readonly IStockMovementRepository _stockMovementRepository;

    public CreateStockMovementCommandHandler(
        IProductRepository productRepository,
        IStockMovementRepository stockMovementRepository)
    {
        _productRepository = productRepository;
        _stockMovementRepository = stockMovementRepository;
    }

    public async Task<Guid> Handle(
        CreateStockMovementCommand request,
        CancellationToken cancellationToken)
    {
        var dto = request.StockMovement;

        var product = await _productRepository.GetByIdAsync(
            dto.ProductId);

        if (product is null)
            throw new KeyNotFoundException(
                "Product not found.");

        product.ApplyStockMovement(
            dto.MovementType,
            dto.Quantity);

        var movement = new StockMovement(
            dto.ProductId,
            dto.MovementType,
            dto.Quantity,
            dto.Reason);

        await _stockMovementRepository.AddAsync(movement);

        await _productRepository.UpdateAsync(product);

        return movement.Id;
    }
}