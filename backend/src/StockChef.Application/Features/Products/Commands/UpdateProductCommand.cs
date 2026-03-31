using MediatR;

namespace StockChef.Application.Features.Products.Commands;

public class UpdateProductCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal UnitPrice { get; set; }
}