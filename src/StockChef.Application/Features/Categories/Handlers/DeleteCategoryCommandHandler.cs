using MediatR;
using StockChef.Application.Features.Categories.Commands;
using StockChef.Application.Interfaces;

namespace StockChef.Application.Features.Categories.Handlers;

public class DeleteCategoryCommandHandler
    : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly ICategoryRepository _repository;

    public DeleteCategoryCommandHandler(
        ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id);

        if (category is null)
            return false;

        await _repository.DeleteAsync(category);

        return true;
    }
}