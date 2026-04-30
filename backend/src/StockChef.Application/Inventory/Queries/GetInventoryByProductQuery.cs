public class GetInventoryByProductQuery : IRequest<List<InventoryDto>>
{
    public Guid ProductId { get; set; }
}