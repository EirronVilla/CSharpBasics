using SmartMarketConsole.Data;
using SmartMarketConsole.Models;
using SmartMarketConsole.Repositories.Interfaces;

namespace SmartMarketConsole.Repositories.Impl
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbContext _dbContext;

        public CustomerRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddCustomer(Customer customer)
        {
            try
            {
                _dbContext.CustomerStorage.Add(customer.Id, customer);
                return true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("A customer with the same ID already exists.");
                return false;
            }
        }

        public void DeleteCustomer(int customerId)
        {
            var removedSuccessfully = _dbContext.CustomerStorage.Remove(customerId);
            if (!removedSuccessfully)
            {
                Console.WriteLine("Customer not found.");
                throw new Exception("Customer not found");
            }
        }

        public ICollection<Customer> GetAllCustomers()
        {
            try
            {
                return _dbContext.CustomerStorage.Values.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving customers: {ex.Message}");
                return new List<Customer>();
            }
        }

        public Customer? GetCustomerById(int customerId)
        {
            try
            {
                var customer = _dbContext.CustomerStorage[customerId];
                if (customer is null)
                {
                    throw new KeyNotFoundException();
                }

                return customer;
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Customer not found.");
                return null;
            }
        }

        public int GetNextCustomerId()
        {
            return _dbContext.CustomerStorage.Count == 0 ? 1 : _dbContext.CustomerStorage.Keys.Max() + 1;
        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                _dbContext.CustomerStorage[customer.Id] = customer;
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Customer not found.");
                throw new Exception("Customer not found");
            }
        }
    }
}
