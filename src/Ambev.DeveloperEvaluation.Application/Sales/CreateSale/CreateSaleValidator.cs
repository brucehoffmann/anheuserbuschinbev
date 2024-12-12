﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleCommandValidator()
        {
            RuleFor(sale => sale.Products.Count)
            .GreaterThan(0).WithMessage("At least one product must be informed.");

            RuleFor(sale => sale.SaleNumber).NotNull().WithMessage("SaleNumber must be informed.");
            RuleFor(sale => sale.Branch).NotNull().NotEmpty().WithMessage("Branch must be informed.");
            RuleFor(sale => sale.Customer).NotNull().NotEmpty().WithMessage("Costumer must be informed.");
            RuleFor(sale => sale.SaleDate).NotNull().NotEmpty().WithMessage("SaleDate must be informed.");
        }
    }
}
