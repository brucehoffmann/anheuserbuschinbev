using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            if (command.Products.Any(p => p.Quantity > 20))
                throw new ValidationException($"The maximum quantity per item is 20.");

            foreach (var product in command.Products)
            {
                product.TotalAmount = product.UnitPrice * product.Quantity;
                product.Discount = 0;

                if (product.Quantity > 4 && product.Quantity < 10)
                {
                    product.Discount = (product.UnitPrice * product.Quantity) / 10; //10% discount
                }
                else if (product.Quantity >= 10 && product.Quantity <= 20)
                {
                    product.Discount = (product.UnitPrice * product.Quantity) / 5; //20% discount
                }
            }

            command.TotalSaleAmount = command.Products.Sum(p => p.TotalAmount - p.Discount);

            var sale = _mapper.Map<Sale>(command);

            var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);
            var result = _mapper.Map<CreateSaleResult>(createdSale);
            return result;
        }
    }
}
