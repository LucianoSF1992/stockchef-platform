using MediatR;
using StockChef.Application.DTOs.Products;

namespace StockChef.Application.Features.Products.Queries;

public record GetAllProductsQuery()
    : IRequest<IEnumerable<ProductDto>>;