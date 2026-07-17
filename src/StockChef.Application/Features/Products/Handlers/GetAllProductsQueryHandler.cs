using MediatR;
using StockChef.Application.DTOs.Products;
using StockChef.Application.Features.Products.Queries;
using StockChef.Application.Interfaces;

namespace StockChef.Application.Features.Products.Handlers;

public class GetAllProductsQueryHandler
    : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IProductRepository _repository;

    public GetAllProductsQueryHandler(
        IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductDto>> Handle(
        GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync();

        return products.Select(product => new ProductDto
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
        });
    }
}