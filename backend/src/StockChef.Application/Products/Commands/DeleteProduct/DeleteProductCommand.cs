using MediatR;

public class DeleteProductCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}