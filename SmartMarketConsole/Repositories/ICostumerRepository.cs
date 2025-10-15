using SmartMarketConsole.Models;

namespace SmartMarketConsole.Repositories
{
    public interface ICostumerRepository
    {
        public bool AddCustomer(Customer customer);
        public Customer? GetCustomerById(int customerId);
        public void UpdateCustomer(Customer customer);
        public void DeleteCustomer(int customerId);
        public List<Customer> GetAllCustomers();    
    }
}
