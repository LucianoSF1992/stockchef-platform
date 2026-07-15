using MediatR;
using StockChef.Application.DTOs.Categories;

namespace StockChef.Application.Features.Categories.Queries;

public record GetAllCategoriesQuery()
    : IRequest<IEnumerable<CategoryDto>>;