using FluentValidation;
using StockChef.Application.Features.Suppliers.Commands;

namespace StockChef.Application.Features.Suppliers.Validators;

public class CreateSupplierCommandValidator
    : AbstractValidator<CreateSupplierCommand>
{
    public CreateSupplierCommandValidator()
    {
        RuleFor(x => x.Supplier.Name)
            .NotEmpty()
            .WithMessage("O nome do fornecedor é obrigatório.")
            .MaximumLength(150)
            .WithMessage("O nome do fornecedor deve possuir no máximo 150 caracteres.");

        RuleFor(x => x.Supplier.TradeName)
            .MaximumLength(150)
            .WithMessage("O nome fantasia deve possuir no máximo 150 caracteres.");

        RuleFor(x => x.Supplier.Cnpj)
            .NotEmpty()
            .WithMessage("O CNPJ do fornecedor é obrigatório.");

        RuleFor(x => x.Supplier.Email)
            .EmailAddress()
            .When(x => !string.IsNullOrWhiteSpace(x.Supplier.Email))
            .WithMessage("O e-mail do fornecedor é inválido.");

        RuleFor(x => x.Supplier.Phone)
            .MaximumLength(30)
            .WithMessage("O telefone deve possuir no máximo 30 caracteres.");

        RuleFor(x => x.Supplier.ContactPerson)
            .MaximumLength(150)
            .WithMessage("O nome do responsável deve possuir no máximo 150 caracteres.");
    }
}