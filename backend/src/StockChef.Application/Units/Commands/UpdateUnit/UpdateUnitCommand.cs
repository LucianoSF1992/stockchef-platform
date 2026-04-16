using MediatR;
public record UpdateUnitCommand(Guid Id, string Name) : IRequest;