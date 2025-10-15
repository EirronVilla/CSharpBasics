namespace SmartMarketConsole.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public LinkedList<Transaction> PurchaseHistory { get; set; } = new LinkedList<Transaction>();

        public Customer()
        {
            Id = 0;
            Name = "";
            Email = "";
            Phone = "";
            PurchaseHistory = new LinkedList<Transaction>();
        }

        public Customer(int id, string name, string email, string phone)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
        }

        /// <summary>
        /// String representation of the Customer object.
        /// </summary>
        /// <returns>String.</returns>
        override
        public string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Email: {Email}, Phone: {Phone}.";
        }
    }
}
