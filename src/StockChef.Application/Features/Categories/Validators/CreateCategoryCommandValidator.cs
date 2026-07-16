using FluentValidation;
using StockChef.Application.Features.Categories.Commands;

namespace StockChef.Application.Features.Categories.Validators;

public class CreateCategoryCommandValidator
    : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Category.Name)
            .NotEmpty()
            .WithMessage("O nome da categoria é obrigatório.")
            .MaximumLength(100)
            .WithMessage("O nome da categoria deve possuir no máximo 100 caracteres.");

        RuleFor(x => x.Category.Description)
            .MaximumLength(500)
            .WithMessage("A descrição deve possuir no máximo 500 caracteres.");
    }
}