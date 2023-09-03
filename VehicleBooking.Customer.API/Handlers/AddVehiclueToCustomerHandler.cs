using CustomersAPI.Commands;
using CustomersAPI.Interfaces;
using CustomersAPI.Models;
using MediatR;

namespace CustomersAPI.Handlers
{
    public class AddVehiclueToCustomerHandler : IRequestHandler<AddVehicleToCustomerCommand, Customer>
    {
        private readonly ICustomerService _customerService;

        public AddVehiclueToCustomerHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<Customer> Handle(AddVehicleToCustomerCommand command, CancellationToken cancellationToken)
        {
            Customer customer = new Customer()
            {
                Name = command!.Name,
                Phone = command!.Phone,
                Email = command!.Email,
                Vehicle=command.Vehicle,
            };



            return await _customerService.AddVehicleToCustomer(customer);
        }
    }

   
}
