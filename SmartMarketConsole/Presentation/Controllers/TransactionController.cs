using SmartMarketConsole.Presentation.Views;
using SmartMarketConsole.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMarketConsole.Presentation.Controllers
{
    public class TransactionController
    {
        private readonly ITransactionService _transactionService;
        private readonly TransactionView _transactionView;

        public TransactionController(ITransactionService transactionService, TransactionView transactionView)
        {
            _transactionService = transactionService;
            _transactionView = transactionView;
        }

        public void AddTransaction()
        {
            var customerId = _transactionView.EnterCustomerId();
            var productIds = _transactionView.EnterProductIds();
            var date = DateTime.UtcNow.ToString("o");
            _transactionService.AddTransaction(customerId, productIds, date);
        }

        public void AddAdditionalProductsToTransaction()
        {
            var transactionId = _transactionView.EnterTransactionId();
            var productIds = _transactionView.EnterProductIds();
            _transactionService.AddAdditionalProductsToTransaction(transactionId, productIds);
        }

        public void DisplayTransactions()
        {
            var transactions = _transactionService.GetAllTransactions();
            _transactionView.DisplayTransactions(transactions);
        }

        public void SearchTransaction()
        {
            var transactionId = _transactionView.EnterTransactionId();
            var transaction = _transactionService.GetTransactionById(transactionId);
            if(transaction is null)
            {
                Console.WriteLine("Transaction not found.");
                return;
            }
            _transactionView.DisplayTransactions([transaction]);
        }

        public void DeleteTransaction()
        {
            var transactionId = _transactionView.EnterTransactionId();
            var transaction = _transactionService.GetTransactionById(transactionId);

            if(transaction is null)
            {
                Console.WriteLine("Transaction not found.");
                return;
            }

            _transactionService.DeleteTransaction(transactionId);
        }
    }
}
