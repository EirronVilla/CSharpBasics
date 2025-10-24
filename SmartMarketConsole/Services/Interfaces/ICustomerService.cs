using SmartMarketConsole.Models;

namespace SmartMarketConsole.Services.Interfaces
{
    public interface ICustomerService
    {
        public ICollection<Customer> GetAllCustomers();
        public Customer? GetCustomerById(int customerId);
        public bool AddCustomer(string name, string email, string phone);
        public void DeleteCustomer(int customerId);
        public bool UpdateCustomers(int customerId, string name, string email, string phone);
        public bool AddTransactionToCustomer(int customerId, int transactionId);
    }
}
