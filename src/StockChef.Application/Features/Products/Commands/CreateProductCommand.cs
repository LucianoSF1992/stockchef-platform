using MediatR;
using StockChef.Application.DTOs.Products;

namespace StockChef.Application.Features.Products.Commands;

public record CreateProductCommand(
    CreateProductDto Product)
    : IRequest<Guid>;