using SmartMarketConsole.Models;

namespace SmartMarketConsole.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        public bool AddTransaction(Transaction transaction);
        public Transaction? GetTransactionById(int transactionId);
        public void UpdateTransaction(Transaction transaction);
        public void DeleteTransaction(int transactionId);
        public ICollection<Transaction> GetAllTransactions();
        public int GetNextTransactionId();
    }
}
