using SmartMarketConsole.Data;
using SmartMarketConsole.Presentation;
using SmartMarketConsole.Presentation.Controllers;
using SmartMarketConsole.Presentation.Views;
using SmartMarketConsole.Repositories.Impl;
using SmartMarketConsole.Repositories.Interfaces;
using SmartMarketConsole.Services.Impl;
using SmartMarketConsole.Services.Interfaces;

namespace SmartMarketConsole
{
    public class Program
    {
        private static void ConfigureServices(ServiceContainer services)
        {
            // Registering services in Service
            // Database Context
            services.RegisterSingleton<IDbContext, DbContext>();

            // Register repositories
            services.RegisterTransient<IProductRepository, ProductRepository>();
            services.RegisterTransient<ICategoryRepository, CategoryRepository>();
            services.RegisterTransient<ICustomerRepository, CustomerRepository>();
            services.RegisterTransient<ITransactionRepository, TransactionRepository>();

            // Registering services
            services.RegisterTransient<IProductService, ProductService>();
            services.RegisterTransient<ICategoryService, CategoryService>();
            services.RegisterTransient<ICustomerService, CustomerService>();
            services.RegisterTransient<ITransactionService, TransactionService>();

            // Registering views
            services.RegisterTransient<CategoryView, CategoryView>();
            services.RegisterTransient<CustomerView, CustomerView>();
            services.RegisterTransient<ProductView, ProductView>();
            services.RegisterTransient<TransactionView, TransactionView>();

            // controllers
            services.RegisterTransient<CategoryController, CategoryController>();
            services.RegisterTransient<CustomerController, CustomerController>();
            services.RegisterTransient<ProductController, ProductController>();
            services.RegisterTransient<TransactionController, TransactionController>();
        }

        static void Main(string[] args)
        {
            var ServiceCollection = new ServiceContainer();
            ConfigureServices(ServiceCollection);

            var mainController = new MainController(
                new MainView(),
                ServiceCollection.Resolve<CustomerController>(),
                ServiceCollection.Resolve<CategoryController>(),
                ServiceCollection.Resolve<ProductController>(),
                ServiceCollection.Resolve<TransactionController>()
            );

            mainController.Run();
        }
    }
}
