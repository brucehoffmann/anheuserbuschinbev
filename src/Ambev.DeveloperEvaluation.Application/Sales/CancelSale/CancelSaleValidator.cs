using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    public class CancelSaleCommandValidator : AbstractValidator<CancelSaleCommand>
    {
        public CancelSaleCommandValidator()
        {
            RuleFor(sale => sale.Id).NotNull().WithMessage("Id must be informed.");
        }
    }
}
