using SmartMarketConsole.Models;

namespace SmartMarketConsole.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        public bool AddCustomer(Customer customer);
        public Customer? GetCustomerById(int customerId);
        public void UpdateCustomer(Customer customer);
        public void DeleteCustomer(int customerId);
        public ICollection<Customer> GetAllCustomers();    
        public int GetNextCustomerId();
    }
}
