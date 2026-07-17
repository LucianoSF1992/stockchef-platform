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
            throw new Exception("Produto não encontrado.");

        // A implementação da atualização da entidade será feita
        // posteriormente, quando criarmos os métodos de domínio.

        await _repository.UpdateAsync(product);
    }
}