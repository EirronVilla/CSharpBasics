using SmartMarketConsole.Data;
using SmartMarketConsole.Models;

namespace SmartMarketConsole.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DbContext _dbContext = DbContext.GetInstance();

        public bool AddTransaction(Transaction transaction)
        {
            try
            {
                _dbContext.TransactionStorage.Add(transaction.Id, transaction);
                return true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("A transaction with the same ID already exists.");
                return false;
            }
        }

        public void DeleteTransaction(int transactionId)
        {
            var removedSuccessfully = _dbContext.TransactionStorage.Remove(transactionId);
            if (!removedSuccessfully)
            {
                Console.WriteLine("Transaction not found.");
                throw new Exception("Transaction not found");
            }
        }

        public List<Transaction> GetAllTransactions()
        {
            try
            {
                return _dbContext.TransactionStorage.Values.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving transactions: {ex.Message}");
                return new List<Transaction>();
            }
        }

        public Transaction? GetTransactionById(int transactionId)
        {
            try
            {
                var transaction = _dbContext.TransactionStorage[transactionId];
                if (transaction is null)
                {
                    throw new KeyNotFoundException();
                }

                return transaction;
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Transaction not found.");
                return null;
            }
        }

        public void UpdateTransaction(Transaction transaction)
        {
            try
            {
                _dbContext.TransactionStorage[transaction.Id] = transaction;
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Transaction not found.");
                throw new Exception("Transaction not found");
            }
        }
    }
}
