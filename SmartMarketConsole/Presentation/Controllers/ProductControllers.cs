using SmartMarketConsole.Models;
using SmartMarketConsole.Presentation.Views;
using SmartMarketConsole.Services;

namespace SmartMarketConsole.Presentation.Controllers
{
    public class ProductControllers
    {
        private readonly IProductService _productService;
        private readonly ProductView _productsView;

        public ProductControllers(IProductService productService, ProductView productsView)
        {
            _productService = productService;
            _productsView = productsView;
        }

        public void AddProduct()
        {
            string name = _productsView.EnterProductName();
            decimal price = _productsView.EnterProductPrice();
            int categoryId = _productsView.EnterProductCategoryId();
            int stockQuantity = _productsView.EnterProductStockQuantity();
            _productService.AddProduct(name, 1, price, stockQuantity);
        }

        public void DeleteProduct()
        {
            int productId = _productsView.EnterProductId();
            var product = _productService.GetProductById(productId);
            if (product == null)
            {
                Console.WriteLine($"Product with ID {productId} not found.");
                return;
            }
            _productService.DeleteProduct(productId);
            Console.WriteLine($"Product with ID {productId} deleted successfully.");
        }

        public void UpdateProduct()
        {
            int productId = _productsView.EnterProductId();
            var product = _productService.GetProductById(productId);
            if (product == null)
            {
                Console.WriteLine($"Product with ID {productId} not found.");
                return;
            }
            string name = _productsView.EnterProductName();
            decimal price = _productsView.EnterProductPrice();
            int categoryId = _productsView.EnterProductCategoryId();
            int stockQuantity = _productsView.EnterProductStockQuantity();
            var updated = _productService.UpdateProduct(productId, name, categoryId, price, stockQuantity);

            if(updated)
            {
                Console.WriteLine($"Product with ID {productId} updated successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to update product with ID {productId}.");
            }
        }

        public void ListProducts()
        {
            var products = _productService.GetAllProducts();
            _productsView.DisplayProducts(products);
        }
    }
}
