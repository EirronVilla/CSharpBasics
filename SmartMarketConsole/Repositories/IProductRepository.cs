using SmartMarketConsole.Models;

namespace SmartMarketConsole.Repositories
{
    public interface IProductRepository
    {
        public bool AddProduct(Product product);
        public Product? GetProductById(int productId);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int productId);
        public List<Product> GetAllProducts();
        public int GetNextProductId();
    }
}
