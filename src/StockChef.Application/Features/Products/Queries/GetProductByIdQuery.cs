using MediatR;
using StockChef.Application.DTOs.Products;

namespace StockChef.Application.Features.Products.Queries;

public record GetProductByIdQuery(Guid Id)
    : IRequest<ProductDto?>;