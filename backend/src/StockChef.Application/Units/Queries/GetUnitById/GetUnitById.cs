using MediatR;
public record GetUnitByIdQuery(Guid Id) : IRequest<UnitDto>;