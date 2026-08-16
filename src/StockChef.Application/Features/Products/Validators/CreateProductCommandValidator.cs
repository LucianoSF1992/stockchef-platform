using FluentValidation;
using StockChef.Application.Features.Products.Commands;

namespace StockChef.Application.Features.Products.Validators;

public class CreateProductCommandValidator
    : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Product.Name)
            .NotEmpty()
            .WithMessage("O nome do produto é obrigatório.")
            .MaximumLength(150)
            .WithMessage("O nome do produto deve possuir no máximo 150 caracteres.");

        RuleFor(x => x.Product.Description)
            .MaximumLength(500)
            .WithMessage("A descrição deve possuir no máximo 500 caracteres.");

        RuleFor(x => x.Product.Sku)
            .NotEmpty()
            .WithMessage("O SKU do produto é obrigatório.");

        RuleFor(x => x.Product.UnitOfMeasure)
            .IsInEnum()
            .WithMessage("A unidade de medida informada é inválida.");

        RuleFor(x => x.Product.MinimumStock)
            .GreaterThanOrEqualTo(0)
            .WithMessage("O estoque mínimo não pode ser negativo.");

        RuleFor(x => x.Product.CostPrice)
            .GreaterThanOrEqualTo(0)
            .WithMessage("O preço de custo não pode ser negativo.");

        RuleFor(x => x.Product.SalePrice)
            .GreaterThanOrEqualTo(0)
            .WithMessage("O preço de venda não pode ser negativo.");

        RuleFor(x => x.Product.CategoryId)
            .NotEmpty()
            .WithMessage("A categoria do produto é obrigatória.");

        RuleFor(x => x.Product.SupplierId)
            .NotEmpty()
            .WithMessage("O fornecedor do produto é obrigatório.");
    }
}