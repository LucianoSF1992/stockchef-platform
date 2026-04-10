using MediatR;
using StockChef.Domain.Entities;

public record GetCompanyByIdQuery(Guid Id) : IRequest<Company?>;