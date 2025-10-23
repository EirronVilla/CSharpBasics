using SmartMarketConsole.Models;
namespace SmartMarketConsole.Data
{
    public interface IDbContext
    {
        Dictionary<int, Product> ProductStorage { get; }
        Dictionary<int, Customer> CustomerStorage { get; }
        Dictionary<int, Category> CategoryStorage { get; }
        Dictionary<int, Transaction> TransactionStorage { get; }
    }
}
