using MediatR;

public class UpdateUnitCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}