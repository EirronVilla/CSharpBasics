using SmartMarketConsole.Models;
using SmartMarketConsole.Repositories.Interfaces;
using SmartMarketConsole.Services.Interfaces;

namespace SmartMarketConsole.Services.Impl
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository { get; set; }
        private ITransactionRepository _transactionRepository { get; set; }

        public CustomerService(
            ICustomerRepository customerRepo, 
            ITransactionRepository transactionRepo)
        {
            _customerRepository = customerRepo;
            _transactionRepository = transactionRepo;
        }

        public bool AddCustomers(string name, string email, string phone)
        {
            try
            {
                if(string.IsNullOrEmpty(name))
                {
                    throw new Exception("Customer name cannot be empty.");
                }
                if(string.IsNullOrEmpty(email))
                {
                    throw new Exception("Customer email cannot be empty.");
                }
                if(string.IsNullOrEmpty(phone))
                {
                    throw new Exception("Customer phone cannot be empty.");
                }

                var currentId = _customerRepository.GetNextCustomerId();
                var success = _customerRepository.AddCustomer(new Customer(currentId, name, email, phone));
                if(!success)
                {
                    Console.WriteLine("A customer with the same ID already exists.");
                }
                return success;

            } catch(Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the customer: {ex.Message}");
                return false;
            }
        }

        public bool AddTransactionToCustomer(int customerId, int transactionId)
        {
            try
            {
                if (customerId <= 0)
                {
                    throw new Exception("Customer Id must be greater than zero");
                }
                if(transactionId <= 0)
                {
                    throw new Exception("Transaction Id must be greater than zero");
                }

                var currentTransaction = _transactionRepository.GetTransactionById(transactionId);
                if (currentTransaction is null)
                {
                    throw new Exception("Transaction not found");
                }

                var customer = _customerRepository.GetCustomerById(customerId);
                if (customer is null)
                {
                    throw new Exception("Customer not found");
                }

                var result = customer.PurchaseHistory.AddLast(currentTransaction);
                return result is null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding a transaction to the customer: {ex.Message}");
                return false;
            }
        }

        public void DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int customerId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomers(int customerId, string name, string email, string phone)
        {
            throw new NotImplementedException();
        }
    }
}
