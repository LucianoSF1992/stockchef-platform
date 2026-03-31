using MediatR;
using StockChef.Application.DTOs;
using StockChef.Application.Common;

namespace StockChef.Application.Features.Products.Commands;

public class CreateProductCommand : IRequest<Result<ProductDto>>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal UnitPrice { get; set; }
}