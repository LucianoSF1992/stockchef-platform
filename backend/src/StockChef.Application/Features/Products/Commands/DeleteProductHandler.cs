using MediatR;
using StockChef.Application.Interfaces;

namespace StockChef.Application.Features.Products.Commands;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public DeleteProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product is null)
            return false;

        product.Deactivate();

        await _repository.UpdateAsync(product);

        return true;
    }
}