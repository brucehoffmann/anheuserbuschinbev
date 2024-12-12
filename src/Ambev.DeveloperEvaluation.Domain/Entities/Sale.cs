using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a sale in the system.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class Sale: BaseEntity
    {
        public int SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public string Customer {  get; set; } = string.Empty;
        public decimal TotalSaleAmount {  get; set; }
        public string Branch {  get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new List<Product>();
        public bool IsCancelled { get; set; } = false;
        public DateTime SaleCreated {  get; set; }
        public DateTime? SaleModified { get; set; }
        public DateTime? SaleCancelled { get; set; }

        public void Cancel()
        {
            IsCancelled = true;
            SaleModified = DateTime.UtcNow;
            SaleCancelled = DateTime.UtcNow;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new SaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

    }
}
