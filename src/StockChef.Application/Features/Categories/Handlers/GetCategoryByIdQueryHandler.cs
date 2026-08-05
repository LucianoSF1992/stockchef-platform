using MediatR;
using StockChef.Application.DTOs.Categories;
using StockChef.Application.Features.Categories.Queries;
using StockChef.Application.Interfaces;

namespace StockChef.Application.Features.Categories.Handlers;

public class GetCategoryByIdQueryHandler
    : IRequestHandler<GetCategoryByIdQuery, CategoryDto?>
{
    private readonly ICategoryRepository _repository;

    public GetCategoryByIdQueryHandler(
        ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CategoryDto?> Handle(
        GetCategoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id);

        if (category is null)
            return null;

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
    }
}