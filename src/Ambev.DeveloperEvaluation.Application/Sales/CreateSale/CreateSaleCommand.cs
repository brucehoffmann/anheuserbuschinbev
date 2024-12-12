using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        public int SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public string Customer { get; set; } = string.Empty;
        public decimal TotalSaleAmount { get; set; } = 0;
        public string Branch { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new List<Product>();
    }

    public class Product
    {
        public Guid Id { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
