using SmartMarketConsole.Models;

namespace SmartMarketConsole.Services.Interfaces
{
    public interface ITransactionService
    {
        public ICollection<Transaction> GetAllTransactions();
        public Transaction? GetTransactionById(int transactionId);
        public bool AddTransaction(int customerId, ICollection<int> productIds, string date);
        public void DeleteTransaction(int transactionId);
        public bool AddAdditionalProductsToTransaction(int transactionId, ICollection<int> productIds);
    }
}