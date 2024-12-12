using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.Products.Count)
           .GreaterThan(0).WithMessage("At least one product must be informed.");

        RuleForEach(sale => sale.Products).SetValidator(new ProductValidator());
       
        RuleFor(sale => sale.SaleNumber).NotNull().WithMessage("SaleNumber must be informed.");
        RuleFor(sale => sale.Branch).NotNull().NotEmpty().WithMessage("Branch must be informed.");
        RuleFor(sale => sale.Customer).NotNull().NotEmpty().WithMessage("Costumer must be informed.");
        RuleFor(sale => sale.TotalSaleAmount).NotNull().WithMessage("TotalSaleAmount must be informed.");
        RuleFor(sale => sale.SaleDate).NotNull().NotEmpty().WithMessage("SaleDate must be informed.");
    }
}
