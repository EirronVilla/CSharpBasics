using SmartMarketConsole.Models;

namespace SmartMarketConsole.Presentation.Views
{
    public class ProductView
    {
        public int EnterProductId()
        {
            int productId;
            while (true)
            {
                Console.Write("Enter product ID: ");
                string input = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(input, out productId) && productId > 0)
                {
                    return productId;
                }
                Console.WriteLine("Invalid product ID. Please enter a valid positive integer.");
            }
        }

        public string EnterProductName()
        {
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine() ?? string.Empty;
            return productName;
        }

        public int EnterProductCategoryId()
        {
            int categoryId;
            while (true)
            {
                Console.Write("Enter product category ID: ");
                string input = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(input, out categoryId) && categoryId > 0)
                {
                    return categoryId;
                }
                Console.WriteLine("Invalid category ID. Please enter a valid positive integer.");
            }
        }

        public decimal EnterProductPrice()
        {
            decimal price;
            while (true)
            {
                Console.Write("Enter product price: ");
                string input = Console.ReadLine() ?? string.Empty;
                if (decimal.TryParse(input, out price) && price >= 0)
                {
                    return price;
                }
                Console.WriteLine("Invalid price. Please enter a valid non-negative decimal number.");
            }
        }

        public int EnterProductStockQuantity()
        {
            int stockQuantity;
            while (true)
            {
                Console.Write("Enter product stock quantity: ");
                string input = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(input, out stockQuantity) && stockQuantity >= 0)
                {
                    return stockQuantity;
                }
                Console.WriteLine("Invalid stock quantity. Please enter a valid non-negative integer.");
            }
        }

        public void DisplayProducts(List<Product> products)
        {
            foreach(Product p in products)
            {
                Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Category ID: {p.Category.ToString()}, Price: {p.Price}, Stock Quantity: {p.StockQuantity}");
            }
        }
    }
}
