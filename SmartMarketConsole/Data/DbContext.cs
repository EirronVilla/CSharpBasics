using SmartMarketConsole.Models;

namespace SmartMarketConsole.Data
{
    /// <summary>
    /// Class to simulate a database context using in-memory storage.
    /// </summary>
    public class DbContext : IDbContext
    {
        public Dictionary<int, Product> ProductStorage { get; set; }
        public Dictionary<int, Customer> CustomerStorage { get; set; }
        public Dictionary<int, Category> CategoryStorage { get; set; }
        public Dictionary<int, Transaction> TransactionStorage { get; set; }

        public DbContext()
        {
            ProductStorage = new Dictionary<int, Product>();
            CustomerStorage = new Dictionary<int, Customer>();
            CategoryStorage = new Dictionary<int, Category>();
            TransactionStorage = new Dictionary<int, Transaction>();
        }
    }
}
