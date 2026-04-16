using MediatR;
public record DeleteUnitCommand(Guid Id) : IRequest;