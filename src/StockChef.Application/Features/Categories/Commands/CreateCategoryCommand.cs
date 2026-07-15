using MediatR;
using StockChef.Application.DTOs.Categories;

namespace StockChef.Application.Features.Categories.Commands;

public record CreateCategoryCommand(
    CreateCategoryDto Category)
    : IRequest<Guid>;