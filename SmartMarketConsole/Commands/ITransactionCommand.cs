using SmartMarketConsole.Models;

namespace SmartMarketConsole.Commands
{
    /// <summary>
    /// Transaction command to add or undo adding a product to a transaction.
    /// </summary>
    public interface ITransactionCommand
    {
        void ExecuteAddProduct(Product product);
        void UndoAddProduct(int productId);
    }
}
