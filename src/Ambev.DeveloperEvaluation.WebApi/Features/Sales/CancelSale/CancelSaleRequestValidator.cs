﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale
{
    public class CancelSaleRequestValidator : AbstractValidator<CancelSaleRequest>
    {
        public CancelSaleRequestValidator()
        {
            RuleFor(sale => sale.Id).NotNull().WithMessage("Id must be informed.");
        }
    }
}