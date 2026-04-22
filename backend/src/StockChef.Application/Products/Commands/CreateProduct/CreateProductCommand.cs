using MediatR;

public class CreateProductCommand : IRequest<Unit>
{
    public string Name { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public Guid UnitId { get; set; }
}