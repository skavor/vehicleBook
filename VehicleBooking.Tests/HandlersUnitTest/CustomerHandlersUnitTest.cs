using CustomersAPI.Commands;
using CustomersAPI.Handlers;
using CustomersAPI.Models;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using VehiculeTestDriveMicroservice.Tests.Mocks;

namespace VehiculeTestDriveMicroservice.Tests.HandlersUnitTest
{
    public class CustomerHandlersUnitTest
    {

        //unit test for creating customer with vehcile 
        [Fact]
        public async Task AddVehicleToCustomerUnitTest()
        {
            var vehicle = new Vehicle()
            {
                Name = "Renault",
               
            };
            var customer = new Customer()
            {
                Name = "Iskander Th",
                Vehicle = vehicle,
                Email = "iskander.th@outlook.fr",
                Phone = "0758089291"
            };

            var handler = new AddVehiclueToCustomerHandler(CustomerMock.AddVehicleToCustomer().Object);
            var result = await handler.Handle(new AddVehicleToCustomerCommand(customer), CancellationToken.None);
            result.ShouldBeOfType<Customer>();
        }
    }
}
