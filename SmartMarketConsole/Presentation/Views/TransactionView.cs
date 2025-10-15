namespace SmartMarketConsole.Presentation.Views
{
    public class TransactionView
    {
        public int EnterTransactionId()
        {
            int transactionId;
            while (true)
            {
                Console.Write("Enter transaction ID: ");
                string input = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(input, out transactionId) && transactionId > 0)
                {
                    return transactionId;
                }
                Console.WriteLine("Invalid transaction ID. Please enter a valid positive integer.");
            }
        }

        public int EnterCustomerId()
        {
            int customerId;
            while (true)
            {
                Console.Write("Enter customer ID: ");
                string input = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(input, out customerId) && customerId > 0)
                {
                    return customerId;
                }
                Console.WriteLine("Invalid customer ID. Please enter a valid positive integer.");
            }
        }

        public List<int> EnterProductIds()
        {
            List<int> productIds = new List<int>();
            var continueInput = true;
            do
            {
                var validInput = false;
                while (!validInput)
                {
                    Console.Write("Enter product ID: ");
                    validInput = int.TryParse(Console.ReadLine(), out int productId) && productId > 0;
                    if (validInput)
                    {
                        productIds.Add(productId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid product ID. Please enter a valid positive integer.");
                    }
                }

                Console.Write("Do you want to add another product? (y/n): ");
                var input = Console.ReadLine() ?? string.Empty;
                continueInput = input.Equals("y", StringComparison.OrdinalIgnoreCase);
            } while (continueInput);
            return productIds;
        }
    }
}
