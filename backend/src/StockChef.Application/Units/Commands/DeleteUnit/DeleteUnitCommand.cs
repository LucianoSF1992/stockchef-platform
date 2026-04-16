using MediatR;
using UnitMediatR = MediatR.Unit;

public class DeleteUnitCommand : IRequest<UnitMediatR>
{
    public Guid Id { get; set; }
}