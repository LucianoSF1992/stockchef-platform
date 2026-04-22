public class GetProductByIdQuery : IRequest<ProductDto>
{
    public Guid Id { get; set; }
}