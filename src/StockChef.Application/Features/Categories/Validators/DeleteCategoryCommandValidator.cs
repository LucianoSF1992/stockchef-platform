using FluentValidation;
using StockChef.Application.Features.Categories.Commands;

namespace StockChef.Application.Features.Categories.Validators;

public class DeleteCategoryCommandValidator
    : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("O ID da categoria é obrigatório.");
    }
}