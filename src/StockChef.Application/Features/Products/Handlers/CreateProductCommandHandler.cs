using MediatR;
using StockChef.Application.Features.Products.Commands;
using StockChef.Application.Interfaces;
using StockChef.Domain.Entities;

namespace StockChef.Application.Features.Products.Handlers;

public class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(
        IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var dto = request.Product;

        var product = new Product(
            dto.Name,
            dto.Sku,
            dto.UnitOfMeasure,
            dto.MinimumStock,
            dto.CostPrice,
            dto.SalePrice,
            dto.CategoryId,
            dto.SupplierId,
            dto.Description
        );

        await _repository.AddAsync(product);

        return product.Id;
    }
}