using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a product in the sale context.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class Product: BaseEntity
    {
        public decimal Quantity { get; set; } = 0;
        public decimal UnitPrice { get; set; } = 0;
        public decimal Discount { get; set; } = 0;
        public decimal TotalAmount { get; set; } = 0;
        public DateTime? ItemCancelled { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new ProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
