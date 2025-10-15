namespace SmartMarketConsole.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public DateTime Date { get; set; }
        public decimal TotalAmount
        {
            get
            {
                return Products.Select(p => p.Price).Sum();
            }
        }

        public Transaction()
        {
            Id = 0;
            Customer = new Customer();
            Products = new List<Product>();
            Date = DateTime.Now;
        }

        public Transaction(int id, Customer customer, List<Product> products, DateTime date)
        {
            Id = id;
            Customer = customer;
            Products = products;
            Date = date;
        }

        override
        public string ToString()
        {
            var productNames = string.Join(", ", Products.Select(p => p.Name));
            return $"Transaction ID: {Id}, Customer: {Customer.Name}, Products: [{productNames}], Date: {Date}, Total Amount: {TotalAmount:C}";
        }
    }
}
