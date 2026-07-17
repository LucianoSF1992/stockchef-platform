using MediatR;
using StockChef.Application.Features.Products.Commands;
using StockChef.Application.Interfaces;

namespace StockChef.Application.Features.Products.Handlers;

public class DeleteProductCommandHandler
    : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _repository;

    public DeleteProductCommandHandler(
        IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(
        DeleteProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product is null)
            throw new Exception("Produto não encontrado.");

        await _repository.DeleteAsync(product);
    }
}