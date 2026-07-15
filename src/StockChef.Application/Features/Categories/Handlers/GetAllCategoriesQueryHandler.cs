using MediatR;
using StockChef.Application.DTOs.Categories;
using StockChef.Application.Features.Categories.Queries;
using StockChef.Application.Interfaces;

namespace StockChef.Application.Features.Categories.Handlers;

public class GetAllCategoriesQueryHandler
    : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
{
    private readonly ICategoryRepository _repository;

    public GetAllCategoriesQueryHandler(
        ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CategoryDto>> Handle(
        GetAllCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var categories = await _repository.GetAllAsync();

        return categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            IsActive = c.IsActive
        });
    }
}