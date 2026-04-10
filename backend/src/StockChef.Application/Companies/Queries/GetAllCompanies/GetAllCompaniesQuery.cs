using MediatR;
using StockChef.Domain.Entities;

public record GetAllCompaniesQuery() : IRequest<List<Company>>;