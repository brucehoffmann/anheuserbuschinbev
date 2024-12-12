using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.Quantity)
            .GreaterThan(20).WithMessage("The maximum quantity per item is 20.");

        RuleFor(sale => sale.Quantity).GreaterThan(0).WithMessage("The quantity cannot be equal to zero.");
    }
}