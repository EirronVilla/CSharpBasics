using SmartMarketConsole.Models;
using SmartMarketConsole.Repositories.Interfaces;
using SmartMarketConsole.Services.Interfaces;

namespace SmartMarketConsole.Services.Impl
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository { get; set; }
        private ICategoryRepository _categoryRepository { get; set; }

        public ProductService(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public bool AddProduct(string name, int categoryId, decimal price, int stockQuantity)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new Exception("Product name cannot be empty.");
                }

                if (categoryId <= 0)
                {
                    throw new Exception("Category ID must be greater than zero.");
                }

                if (price < 0)
                {
                    throw new Exception("Price cannot be negative.");
                }

                if (stockQuantity < 0)
                {
                    throw new Exception("Stock quantity cannot be negative.");
                }

                var category = _categoryRepository.GetCategoryById(categoryId) ?? throw new Exception("Category does not exist.");
                var currentId = _productRepository.GetNextProductId();

                if (_productRepository.AddProduct(new Product(currentId, name, category, price, stockQuantity)))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("A product with the same ID already exists.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the product: {ex.Message}");
                return false;
            }
        }

        public void DeleteProduct(int productId)
        {
            try
            {
                if (productId <= 0)
                {
                    throw new Exception("Product ID must be greater than zero.");
                }

                var productExists = _productRepository.GetProductById(productId);
                if (productExists is null)
                {
                    throw new Exception("Product does not exist.");
                }

                _productRepository.DeleteProduct(productId);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the product: {ex.Message}");
                throw;
            }
        }

        public Product? GetProductById(int productId)
        {
            try
            {
                if (productId <= 0)
                {
                    throw new Exception("Product ID must be greater than zero.");
                }

                return _productRepository.GetProductById(productId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the product: {ex.Message}");
                return null;
            }
        }

        public bool UpdateProduct(int productId, string name, int categoryId, decimal price, int stockQuantity)
        {
            try
            {
                if (productId <= 0)
                {
                    throw new Exception("Product ID must be greater than zero.");
                }
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new Exception("Product name cannot be empty.");
                }
                if (categoryId <= 0)
                {
                    throw new Exception("Category ID must be greater than zero.");
                }
                if (price < 0)
                {
                    throw new Exception("Price cannot be negative.");
                }
                if (stockQuantity < 0)
                {
                    throw new Exception("Stock quantity cannot be negative.");
                }

                var existingProduct = _productRepository.GetProductById(productId) ?? throw new Exception("Product does not exist.");
                var category = _categoryRepository.GetCategoryById(categoryId) ?? throw new Exception("Category does not exist.");
                var updatedProduct = new Product(productId, name, category, price, stockQuantity);
                _productRepository.UpdateProduct(updatedProduct);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the product: {ex.Message}");
                return false;
            }
        }

        public ICollection<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
    }
}
