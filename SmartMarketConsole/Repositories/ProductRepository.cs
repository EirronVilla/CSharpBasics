using SmartMarketConsole.Data;
using SmartMarketConsole.Models;

namespace SmartMarketConsole.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _dbContext = DbContext.GetInstance();

        public bool AddProduct(Product product)
        {
            try
            {
                _dbContext.ProductStorage.Add(product.Id, product);
                return true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("A product with the same ID already exists.");
                return false;
            }
        }

        public void DeleteProduct(int productId)
        {
            var removedSuccessfully = _dbContext.ProductStorage.Remove(productId);
            if(!removedSuccessfully)
            {
                Console.WriteLine("Product not found.");
                throw new Exception("Product not found");
            }
        }

        public List<Product> GetAllProducts()
        {
            try
            {
                return _dbContext.ProductStorage.Values.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving products: {ex.Message}");
                return new List<Product>();
            }
        }

        public int GetNextProductId()
        {
            return _dbContext.ProductStorage.Count == 0 ? 1 : _dbContext.ProductStorage.Keys.Max() + 1;
        }

        public Product? GetProductById(int productId)
        {
            try
            {
                var product = _dbContext.ProductStorage[productId];
                if(product is null)
                {
                    throw new KeyNotFoundException();
                }

                return product;
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Product not found.");
                return null;
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                _dbContext.ProductStorage[product.Id] = product;
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Product not found.");
                throw new Exception("Product not found");
            }
        }
    }
}
