using SmartMarketConsole.Data;
using SmartMarketConsole.Models;

namespace SmartMarketConsole.Repositories
{
    public class CostumerRepository : ICostumerRepository
    {
        private readonly DbContext _dbContext = DbContext.GetInstance();

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

        public List<Customer> GetAllCustomers()
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
