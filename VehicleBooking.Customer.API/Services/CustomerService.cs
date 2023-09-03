using CustomersAPI.Data;
using CustomersAPI.Interfaces;
using CustomersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomersAPI.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly CustomerApiDbContext _customerDbContext;

        public CustomerService(CustomerApiDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        public async Task<Customer> AddVehicleToCustomer(Customer customer)
        {
            
            var customerToCreate = await _customerDbContext.Customers.AddAsync(customer);
            await _customerDbContext.SaveChangesAsync();
            return customerToCreate.Entity;

               
        }
    }
}
