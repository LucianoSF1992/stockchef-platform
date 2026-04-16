using MediatR;

public class DeleteUnitCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}