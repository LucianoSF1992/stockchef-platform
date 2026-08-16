using FluentValidation;
using StockChef.Application.Features.StockMovements.Queries;

namespace StockChef.Application.Features.StockMovements.Validators;

public class GetStockMovementByIdQueryValidator
    : AbstractValidator<GetStockMovementByIdQuery>
{
    public GetStockMovementByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("O ID da movimentação de estoque é obrigatório.");
    }
}