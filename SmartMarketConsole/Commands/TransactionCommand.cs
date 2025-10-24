using SmartMarketConsole.Models;

namespace SmartMarketConsole.Commands
{
    internal class TransactionCommand : ITransactionCommand
    {
        private Transaction _transaction;

        public TransactionCommand(Transaction transaction)
        {
            _transaction = transaction;
        }

        public void ExecuteAddProduct(Product product)
        {
            _transaction.Products.Add(product);
        }

        public void UndoAddProduct(int productId)
        {
            var productToRemove = _transaction.Products.FirstOrDefault(p => p.Id == productId);
            
            if (productToRemove is null)
            {
                return;
            }

            _transaction.Products.Remove(productToRemove);
        }
    }
}
