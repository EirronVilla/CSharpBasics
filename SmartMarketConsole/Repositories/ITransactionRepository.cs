using SmartMarketConsole.Models;

namespace SmartMarketConsole.Repositories
{
    public interface ITransactionRepository
    {
        public bool AddTransaction(Transaction transaction);
        public Transaction? GetTransactionById(int transactionId);
        public void UpdateTransaction(Transaction transaction);
        public void DeleteTransaction(int transactionId);
        public List<Transaction> GetAllTransactions();
    }
}
