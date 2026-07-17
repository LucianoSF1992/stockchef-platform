using MediatR;
using StockChef.Application.DTOs.Products;

namespace StockChef.Application.Features.Products.Commands;

public record UpdateProductCommand(
    Guid Id,
    UpdateProductDto Product)
    : IRequest;