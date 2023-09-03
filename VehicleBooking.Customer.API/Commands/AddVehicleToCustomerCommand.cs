using CustomersAPI.Models;
using MediatR;

namespace CustomersAPI.Commands
{
    public class AddVehicleToCustomerCommand : IRequest<Customer>
    {
        public string? Name { get; set; }
        public Vehicle Vehicle { get; set; }
        public string? Email { get; set; }

        public string? Phone { get; set; }

        
        public AddVehicleToCustomerCommand(Customer customer)
        {
            Name = customer.Name;
            Vehicle = customer.Vehicle;
            Email = customer.Email;
            Phone = customer.Phone;

        }
    }
}
