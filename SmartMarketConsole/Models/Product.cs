namespace SmartMarketConsole.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public Product()
        {
            Id = 0;
            Name = string.Empty;
            Category = new Category();
            Price = 0.0m;
            StockQuantity = 0;
        }

        public Product(int id, string name, Category category, decimal price, int stockQuantity)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
            StockQuantity = stockQuantity;
        }

        /// <summary>
        /// String representation of the Product object.
        /// </summary>
        /// <returns>String.</returns>
        override
        public string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Category: {Category.ToString()}, Price: {Price:C}, Stock: {StockQuantity}";
        }
    }
}
