public class AddStockCommand : IRequest<Unit>
{
    public Guid ProductId { get; set; }
    public Guid UnitId { get; set; }
    public decimal Quantity { get; set; }
}