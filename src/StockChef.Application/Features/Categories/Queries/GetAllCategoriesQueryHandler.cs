using MediatR;
using Microsoft.EntityFrameworkCore;
using StockChef.Application.DTOs.Categories;
using StockChef.Infrastructure.Persistence;

namespace StockChef.Application.Features.Categories.Queries;

public class GetAllCategoriesQueryHandler
    : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
{
    private readonly StockChefDbContext _context;

    public GetAllCategoriesQueryHandler(
        StockChefDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CategoryDto>> Handle(
        GetAllCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Categories
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                IsActive = c.IsActive
            })
            .ToListAsync(cancellationToken);
    }
}