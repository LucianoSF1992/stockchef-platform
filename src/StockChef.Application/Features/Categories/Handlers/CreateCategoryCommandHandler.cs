using MediatR;
using StockChef.Application.Features.Categories.Commands;
using StockChef.Application.Interfaces;
using StockChef.Domain.Entities;

namespace StockChef.Application.Features.Categories.Handlers;

public class CreateCategoryCommandHandler
    : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly ICategoryRepository _repository;

    public CreateCategoryCommandHandler(
        ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(
        CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var category = new Category(
            request.Category.Name,
            request.Category.Description);

        await _repository.AddAsync(category);

        return category.Id;
    }
}