using MediatR;
using StockChef.Application.DTOs.Categories;

namespace StockChef.Application.Features.Categories.Queries;

public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
{
}