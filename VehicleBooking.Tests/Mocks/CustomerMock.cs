using CustomersAPI.Interfaces;
using CustomersAPI.Models;
using Moq;

namespace VehiculeTestDriveMicroservice.Tests.Mocks
{
    internal class CustomerMock
    {
        //Mock to add vehicle to customer
        public static Mock<ICustomerService> AddVehicleToCustomer()
        {

            var mockCustomerRepository = new Mock<ICustomerService>();
            mockCustomerRepository.Setup(_repository => _repository.AddVehicleToCustomer(It.IsAny<Customer>())).ReturnsAsync(new Customer());
            return mockCustomerRepository;
        }
    }
}
