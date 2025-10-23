using SmartMarketConsole.Models;

namespace SmartMarketConsole.Services.Interfaces
{
    public interface IProductService
    {
        public ICollection<Product> GetAllProducts();
        public Product? GetProductById(int productId);
        public bool AddProduct(string name, int categoryId, decimal price, int stockQuantity);
        public void DeleteProduct(int productId);
        public bool UpdateProduct(int productId, string name, int categoryId, decimal price, int stockQuantity);
    }
}
