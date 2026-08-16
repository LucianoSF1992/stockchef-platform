using FluentValidation;
using StockChef.Application.Features.Products.Commands;

namespace StockChef.Application.Features.Products.Validators;

public class DeleteProductCommandValidator
    : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("O ID do produto é obrigatório.");
    }
}