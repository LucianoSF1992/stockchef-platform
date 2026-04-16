using MediatR;

public class DeleteUnitCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

    public DeleteUnitCommand(Guid id)
    {
        Id = id;
    }
}