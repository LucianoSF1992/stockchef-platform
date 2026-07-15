using MediatR;
using StockChef.Application.DTOs.Categories;

namespace StockChef.Application.Features.Categories.Commands;

public class CreateCategoryCommand : IRequest<Guid>
{
    public CreateCategoryDto Category { get; set; } = null!;

    public CreateCategoryCommand(CreateCategoryDto category)
    {
        Category = category;
    }
}