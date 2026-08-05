using MediatR;
using StockChef.Application.Features.Categories.Commands;
using StockChef.Application.Interfaces;

namespace StockChef.Application.Features.Categories.Handlers;

public class UpdateCategoryCommandHandler
    : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly ICategoryRepository _repository;

    public UpdateCategoryCommandHandler(
        ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        UpdateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id);

        if (category is null)
            return false;

        category.Update(
            request.Category.Name,
            request.Category.Description);

        await _repository.UpdateAsync(category);

        return true;
    }
}