using MediatR;
using UnitMediatR = MediatR.Unit;

public class UpdateUnitCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}