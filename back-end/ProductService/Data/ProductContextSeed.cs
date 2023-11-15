using ProductService.Enums;
using ProductService.Models;

namespace ProductService.Data
{
    public class ProductContextSeed
    {
        public static void Seed(ProductsContext context)
        {
            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product(1, 20, "Laptop", "Powerful laptop for professionals", 1299.99m, DateTime.UtcNow.AddDays(-30)),
                    new Product(2, 5, "Smartphone", "Latest model with advanced features", 799.99m, DateTime.UtcNow.AddDays(-25)),
                    new Product(3, 15, "Headphones", "Noise-canceling headphones for immersive audio", 149.99m, DateTime.UtcNow.AddDays(-20)),
                    new Product(4, 8, "Coffee Maker", "Espresso machine for coffee enthusiasts", 199.99m, DateTime.UtcNow.AddDays(-18)),
                    new Product(5, 30, "Fitness Tracker", "Track your daily activities and workouts", 49.99m, DateTime.UtcNow.AddDays(-15)),
                    new Product(6, 2, "Digital Camera", "High-resolution camera for photography enthusiasts", 699.99m, DateTime.UtcNow.AddDays(-10)),
                    new Product(7, 0, "Gaming Console", "Next-gen gaming console for immersive gaming", 499.99m, DateTime.UtcNow.AddDays(-5)),
                    new Product(8, 12, "Bluetooth Speaker", "Portable speaker with high-quality sound", 79.99m, DateTime.UtcNow.AddDays(-3)),
                    new Product(9, 25, "External Hard Drive", "Expand your storage capacity with this external drive", 129.99m, DateTime.UtcNow.AddDays(-2)),
                    new Product(10, 3, "Wireless Mouse", "Ergonomic mouse for comfortable usage", 29.99m, DateTime.UtcNow.AddDays(-1)),
                    new Product(11, 0, "Smartwatch", "Stay connected with notifications on your wrist", 199.99m, DateTime.UtcNow),
                    new Product(12, 18, "Portable Charger", "Charge your devices on the go with this portable charger", 39.99m, DateTime.UtcNow),
                    new Product(13, 7, "Desk Organizer", "Keep your workspace tidy with this organizer", 19.99m, DateTime.UtcNow),
                    new Product(14, 10, "Backpack", "Stylish backpack for everyday use", 49.99m, DateTime.UtcNow),
                    new Product(15, 1, "Home Security Camera", "Monitor your home with this smart security camera", 89.99m, DateTime.UtcNow)
                };
                context.AddRange(products);
                context.SaveChanges();
            }
        }

    }
}
