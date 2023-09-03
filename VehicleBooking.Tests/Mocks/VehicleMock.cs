using Moq;
using System.Collections.Generic;
using VehiculeAPI.Interfaces;
using VehiculeAPI.Models;

namespace VehiculeTestDriveMicroservice.Tests.Mocks
{
    internal class VehicleMock
    {
        //Mock to get vehicle list
        public static Mock<IVehicleService> GetVehicleList()
        {


            var mockVehicleRepository = new Mock<IVehicleService>();
            mockVehicleRepository.Setup(_repository => _repository.GetAllVehicles()).ReturnsAsync(new List<Vehicle>());

            return mockVehicleRepository;
        }

        //Mock to add new vehicle
        public static Mock<IVehicleService> AddVehicle()
        {

            var mockVehicleRepository = new Mock<IVehicleService>();
            mockVehicleRepository.Setup(_repository => _repository.AddVehicle(It.IsAny<Vehicle>())).ReturnsAsync(new Vehicle());
            return mockVehicleRepository;
        }
    }
}
