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

        public void UndoAddProduct()
        {
            _transaction.Products.RemoveAt(_transaction.Products.Count - 1);
        }
    }
}
