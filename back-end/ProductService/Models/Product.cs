using ProductService.Enums;

namespace ProductService.Models
{
    public class Product
    {
        public Product()
        {

        }

        public Product(int id, int stock, string name, string description, double price, DateTime createdTime)
        {
            ProductId = id;
            Stock = stock;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Price = price;
            CreatedTime = createdTime;
            Status = CalculateStatus(stock);
        }

        public Product(int productId, int stock, string name, string description, double price, DateTime createdTime, ProductStatus status) : this(productId, stock, name, description, price, createdTime) => Status = status;

        public int ProductId { get; set; }
        public int Stock { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; } 
        public DateTime CreatedTime { get; set; }
        public ProductStatus Status { get; set; }

        public ProductStatus CalculateStatus(int stock)
        {
            if (stock < 0)
                throw new ArgumentOutOfRangeException(nameof(stock));

            if (stock >= 10)
            {
                return ProductStatus.IN_STOCK;
            }
            else if (stock < 10)
            {
                return ProductStatus.LOW_STOCK;
            }
            return ProductStatus.NONE;
        }
    }
}
