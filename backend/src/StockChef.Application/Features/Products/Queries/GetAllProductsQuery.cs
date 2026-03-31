using MediatR;
using StockChef.Application.DTOs;

namespace StockChef.Application.Features.Products.Queries;

public record GetAllProductsQuery() : IRequest<List<ProductDto>>;