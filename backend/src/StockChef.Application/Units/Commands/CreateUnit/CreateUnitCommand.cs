using MediatR;

public record CreateUnitCommand(string Name, Guid CompanyId) : IRequest<Guid>;