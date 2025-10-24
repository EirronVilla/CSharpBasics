using SmartMarketConsole.Presentation.Controllers;

namespace SmartMarketConsole.Presentation
{
    public class MainController
    {
        private readonly MainView _mainView;
        private readonly CustomerController _customerController;
        private readonly CategoryController _categoryController;
        private readonly ProductController _productController;
        private readonly TransactionController _transactionController;

        public MainController(
            MainView mainView,
            CustomerController customerController,
            CategoryController categoryController,
            ProductController productController,
            TransactionController transactionController)
        {
            _mainView = mainView;
            _customerController = customerController;
            _categoryController = categoryController;
            _productController = productController;
            _transactionController = transactionController;
        }

        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                int choice = _mainView.MainMenu();
                switch (choice)
                {
                    case 1:
                        HandleCustomerMenu();
                        break;
                    case 2:
                        HandleCategoryMenu();
                        break;
                    case 3:
                        HandleProductMenu();
                        break;
                    case 4:
                        HandleTransactionMenu();
                        break;
                    case 5:
                        exit = true;
                        Console.WriteLine("Exiting the program. Goodbye!");
                        break;
                }
            }
        }

        private void HandleTransactionMenu()
        {
            bool exit = false;
            while (!exit)
            {
                int choice = _mainView.TransactionsMenu();
                switch (choice)
                {
                    case 1:
                        _transactionController.DisplayTransactions();
                        break;
                    case 2:
                        _transactionController.SearchTransaction();
                        break;
                    case 3:
                        _transactionController.AddTransaction();
                        break;
                    case 4:
                        _transactionController.AddAdditionalProductsToTransaction();
                        break;
                    case 5:
                        _transactionController.DeleteTransaction();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Menu not implemented yet.");
                        break;
                }
            }
        }

        private void HandleProductMenu()
        {
            bool exit = false;
            while (!exit)
            {
                int choice = _mainView.ProductsMenu();
                switch (choice)
                {
                    case 1:
                        _productController.ListProducts();
                        break;
                    case 2:
                        _productController.SearchProduct();
                        break;
                    case 3:
                        _productController.SearchProductsByCategory();
                        break;
                    case 4:
                        _productController.AddProduct();
                        break;
                    case 5:
                        _productController.UpdateProduct();
                        break;
                    case 6:
                        _productController.DeleteProduct();
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Menu not implemented yet.");
                        break;
                }
            }
        }

        private void HandleCategoryMenu()
        {
            bool exit = false;
            while (!exit)
            {
                int choice = _mainView.CategoriesMenu();
                switch (choice)
                {
                    case 1:
                        _categoryController.ListCategories();
                        break;
                    case 2:
                        _categoryController.SearchCategory();
                        break;
                    case 3:
                        _categoryController.AddCategory();
                        break;
                    case 4:
                        _categoryController.UpdateCategory();
                        break;
                    case 5:
                        _categoryController.DeleteCategory();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Menu not implemented yet.");
                        break;
                }

                if (!exit)
                {
                    _mainView.WaitForUser();
                }
            }
        }

        private void HandleCustomerMenu()
        {
            bool exit = false;
            while (!exit)
            {
                int choice = _mainView.CostumersMenu();
                switch (choice)
                {
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Menu not implemented yet.");
                        break;
                }
            }
        }
    }
}
