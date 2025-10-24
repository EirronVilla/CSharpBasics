using SmartMarketConsole.Presentation.Views;
using SmartMarketConsole.Services.Impl;
using SmartMarketConsole.Services.Interfaces;

namespace SmartMarketConsole.Presentation.Controllers
{
    public class CustomerController
    {
        private readonly ICustomerService _customerService;
        private readonly CustomerView _customerView;

        public CustomerController(ICustomerService customerService, CustomerView customerView)
        {
            _customerService = customerService;
            _customerView = customerView;
        }

        public void AddCustomer()
        {
            var name = _customerView.EnterCustomerName();
            var email = _customerView.EnterCustomerEmail();
            var phone = _customerView.EnterCustomerPhone();
            _customerService.AddCustomer(name, email, phone);
        }

        public void DeleteCustomer()
        {
            var customerId = _customerView.EnterCustomerId();
            var customer = _customerService.GetCustomerById(customerId);

            if (customer == null)
            {
                Console.WriteLine($"Customer with ID {customerId} not found.");
                return;
            }

            _customerService.DeleteCustomer(customerId);
            Console.WriteLine($"Customer with ID {customerId} deleted successfully.");
        }

        public void UpdateCustomer()
        {
            var customerId = _customerView.EnterCustomerId();
            var customer = _customerService.GetCustomerById(customerId);
            if (customer == null)
            {
                Console.WriteLine($"Customer with ID {customerId} not found.");
                return;
            }
            var name = _customerView.EnterCustomerName();
            var email = _customerView.EnterCustomerEmail();
            var phone = _customerView.EnterCustomerPhone();
            var updated = _customerService.UpdateCustomers(customerId, name, email, phone);
            if (updated)
            {
                Console.WriteLine($"Customer with ID {customerId} updated successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to update customer with ID {customerId}.");
            }
        }

        public void ListCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            _customerView.DisplayCustomers(customers);
        }
    }
}
