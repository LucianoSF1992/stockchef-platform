using MediatR;
using StockChef.Application.DTOs.Categories;

namespace StockChef.Application.Features.Categories.Commands;

public record UpdateCategoryCommand(
    Guid Id,
    UpdateCategoryDto Category)
    : IRequest<bool>;