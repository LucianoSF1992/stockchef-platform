using MediatR;

public class DeleteUnitCommand : IRequest<MediatR.Unit>
{
    public Guid Id { get; set; }
}