using MediatR;
using StockChef.Application.Features.Products.Commands;
using StockChef.Application.Interfaces;

namespace StockChef.Application.Features.Products.Handlers;

public class UpdateProductCommandHandler
    : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(
        IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(
        UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product is null)
            throw new KeyNotFoundException(
                "Produto não encontrado.");

        product.UpdateDetails(
            request.Product.Name,
            request.Product.Sku,
            request.Product.UnitOfMeasure,
            request.Product.MinimumStock,
            request.Product.CostPrice,
            request.Product.SalePrice,
            request.Product.CategoryId,
            request.Product.SupplierId,
            request.Product.Description);

        await _repository.UpdateAsync(product);
    }
}