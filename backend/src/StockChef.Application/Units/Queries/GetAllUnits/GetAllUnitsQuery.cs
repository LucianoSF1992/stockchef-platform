using MediatR;
public record GetAllUnitsQuery() : IRequest<List<UnitDto>>;