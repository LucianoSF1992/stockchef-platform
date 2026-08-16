using FluentValidation;
using StockChef.Application.Features.Suppliers.Commands;

namespace StockChef.Application.Features.Suppliers.Validators;

public class DeleteSupplierCommandValidator
    : AbstractValidator<DeleteSupplierCommand>
{
    public DeleteSupplierCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("O ID do fornecedor é obrigatório.");
    }
}