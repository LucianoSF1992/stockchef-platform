using MediatR;
using StockChef.Application.DTOs.Products;
using StockChef.Application.Features.Products.Queries;
using StockChef.Application.Interfaces;

namespace StockChef.Application.Features.Products.Handlers;

public class GetProductByIdQueryHandler
    : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IProductRepository _repository;

    public GetProductByIdQueryHandler(
        IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductDto?> Handle(
        GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product is null)
            return null;

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Sku = product.Sku,
            UnitOfMeasure = product.UnitOfMeasure,
            MinimumStock = product.MinimumStock,
            CostPrice = product.CostPrice,
            SalePrice = product.SalePrice,
            CategoryId = product.CategoryId,
            SupplierId = product.SupplierId
        };
    }
}