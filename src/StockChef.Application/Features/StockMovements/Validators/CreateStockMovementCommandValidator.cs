using FluentValidation;
using StockChef.Application.Features.StockMovements.Commands;

namespace StockChef.Application.Features.StockMovements.Validators;

public class CreateStockMovementCommandValidator
    : AbstractValidator<CreateStockMovementCommand>
{
    public CreateStockMovementCommandValidator()
    {
        RuleFor(x => x.StockMovement.ProductId)
            .NotEmpty()
            .WithMessage("O produto é obrigatório.");

        RuleFor(x => x.StockMovement.Quantity)
            .GreaterThan(0)
            .WithMessage("A quantidade deve ser maior que zero.");

        RuleFor(x => x.StockMovement.MovementType)
            .IsInEnum()
            .WithMessage("O tipo de movimentação informado é inválido.");

        RuleFor(x => x.StockMovement.Reason)
            .MaximumLength(500)
            .WithMessage("O motivo deve possuir no máximo 500 caracteres.");
    }
}