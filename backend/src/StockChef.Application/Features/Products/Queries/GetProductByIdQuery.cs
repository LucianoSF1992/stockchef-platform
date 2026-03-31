using MediatR;
using StockChef.Application.DTOs;

namespace StockChef.Application.Features.Products.Queries;

public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto?>;