using MediatR;

public record CreateCompanyCommand(string Name, string Document) : IRequest<Guid>;