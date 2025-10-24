using SmartMarketConsole.Commands;
using SmartMarketConsole.Models;
using SmartMarketConsole.Repositories.Interfaces;
using SmartMarketConsole.Services.Interfaces;

namespace SmartMarketConsole.Services.Impl
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public bool AddAdditionalProductsToTransaction(int transactionId, ICollection<int> productIds)
        {
            try
            {
                if(transactionId <= 0)
                {
                    throw new Exception("Transaction ID must be greater than zero.");
                }

                var existingTransaction = GetTransactionById(transactionId);
                if (existingTransaction is null)
                {
                    throw new Exception("Transaction not found.");
                }

                var products = _productRepository.GetAllProducts().Where(product => productIds.Contains(product.Id));

                foreach (var product in products)
                {
                    var command = new TransactionCommand(existingTransaction);
                    command.ExecuteAddProduct(product);
                }

                _transactionRepository.UpdateTransaction(existingTransaction);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding products to the transaction: {ex.Message}");
                return false;
            }
        }

        public bool AddTransaction(int customerId, ICollection<int> productIds, string date)
        {
            try
            {
                if (customerId <= 0)
                {
                    throw new Exception("Customer Id must be greater than 0.");
                }

                if (productIds.Count == 0)
                {
                    throw new Exception("Product count can't be zero.");
                }
                
                var customer = _customerRepository.GetCustomerById(customerId) ?? throw new Exception("Customer does not exist.");
                var products = _productRepository.GetAllProducts().Where(product => productIds.Contains(product.Id)).ToList();
                var currentTransactionId = _transactionRepository.GetNextTransactionId();
                _transactionRepository.AddTransaction(new Transaction(currentTransactionId, customer, products, DateTime.UtcNow));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the transaction: {ex.Message}");
                return false;
            }
        }

        public void DeleteTransaction(int transactionId)
        {
            try
            {
                if(transactionId <= 0)
                {
                    throw new Exception("Transaction ID must be greater than zero.");
                }
                var existingTransaction = GetTransactionById(transactionId);
                if(existingTransaction is null)
                {
                    throw new Exception("Transaction not found.");
                }

                _transactionRepository.DeleteTransaction(transactionId);
            } catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the transaction: {ex.Message}");
                throw;
            }
        }

        public ICollection<Transaction> GetAllTransactions()
        {
            return _transactionRepository.GetAllTransactions();
        }

        public Transaction? GetTransactionById(int transactionId)
        {
            try
            {
                if (transactionId <= 0)
                {
                    throw new Exception("Transaction ID must be greater than zero.");
                }

                var transaction = _transactionRepository.GetTransactionById(transactionId);
                return transaction;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the transaction: {ex.Message}");
                return null;
            }
        }
    }
}
