using SmartMarketConsole.Models;
using SmartMarketConsole.Presentation.Views;
using SmartMarketConsole.Services.Interfaces;

namespace SmartMarketConsole.Presentation.Controllers
{
    public class ProductController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ProductView _productsView;

        public ProductController(IProductService productService, ProductView productsView)
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
            _productService.AddProduct(name, categoryId, price, stockQuantity);
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

        public void SearchProduct()
        {
            var productId = _productsView.EnterProductId();
            var product = _productService.GetProductById(productId);
            
            if(product is null)
            {
                Console.WriteLine($"Product with ID {productId} not found.");
                return;
            }

            _productsView.DisplayProducts([product]);
        }

        public void SearchProductsByCategory()
        {
            var categoryId = _productsView.EnterProductCategoryId();
            var categoryExists = _categoryService.GetCategoryById(categoryId) != null;
            
            if (!categoryExists)
            {
                Console.WriteLine($"Category with ID {categoryId} not found.");
                return;
            }

            var products = _productService.GetAllProducts().Where(product => product.Category.Id == categoryId);

            if(products.Count() == 0)
            {
                Console.WriteLine($"No products found in category ID {categoryId}.");
                return;
            }

            _productsView.DisplayProducts(products.ToList());
        }
    }
}
