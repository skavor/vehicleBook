using CustomersAPI.Models;

namespace CustomersAPI.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> AddVehicleToCustomer(Customer customer);
    }
}
