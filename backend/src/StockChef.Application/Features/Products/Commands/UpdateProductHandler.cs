using MediatR;
using StockChef.Application.Interfaces;

namespace StockChef.Application.Features.Products.Commands;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public UpdateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product is null)
            return false;

        product.Update(request.Name, request.Description, request.UnitPrice);

        await _repository.UpdateAsync(product);

        return true;
    }
}