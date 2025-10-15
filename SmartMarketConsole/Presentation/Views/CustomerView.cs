namespace SmartMarketConsole.Presentation.Views
{
    public class CustomerView
    {
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

        public string EnterCustomerName()
        {
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine() ?? string.Empty;
            return customerName;
        }

        public string EnterCustomerEmail()
        {
            Console.Write("Enter customer email: ");
            string customerEmail = Console.ReadLine() ?? string.Empty;
            return customerEmail;
        }

        public string EnterCustomerPhone()
        {
            Console.Write("Enter customer phone: ");
            string customerPhone = Console.ReadLine() ?? string.Empty;
            return customerPhone;
        }
    }
}
