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


        // Singleton instance
        public static DbContext Instance { get; private set; }

        private DbContext()
        {
            ProductStorage = new Dictionary<int, Product>();
            CustomerStorage = new Dictionary<int, Customer>();
            CategoryStorage = new Dictionary<int, Category>();
            TransactionStorage = new Dictionary<int, Transaction>();
        }

        private DbContext(
            Dictionary<int, Product> productStorage, 
            Dictionary<int, Customer> customerStorage, 
            Dictionary<int, Category> categoryStorage, 
            Dictionary<int, Transaction> transactionStorage)
        {
            ProductStorage = productStorage;
            CustomerStorage = customerStorage;
            CategoryStorage = categoryStorage;
            TransactionStorage = transactionStorage;
        }

        /// <summary>
        /// Using singleton pattern to ensure only one instance of DbContext exists.
        /// </summary>
        /// <returns>Intance of the DbContext</returns>
        public static DbContext GetInstance()
        {
            if (Instance == null)
            {
                Instance = new DbContext(
                    new Dictionary<int, Product>(), 
                    new Dictionary<int, Customer>(), 
                    new Dictionary<int, Category>(), 
                    new Dictionary<int, Transaction>());
            }
            return Instance;
        }
    }
}
