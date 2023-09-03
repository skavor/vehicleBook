using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VehiculeAPI.Commands;
using VehiculeAPI.Handlers;
using VehiculeAPI.Models;
using VehiculeAPI.Queries;
using VehiculeTestDriveMicroservice.Tests.Mocks;
using Xunit;

namespace VehiculeTestDriveMicroservice.Tests.HandlersUnitTest
{
    public class VehicleHandlersUnitTest
    {
        //unit test for getting vehicles list
        [Fact]
        public async Task GetVehiclesListUnitTest()
        {
            var handler = new GetVehiclesListHandler(VehicleMock.GetVehicleList().Object);
            var result = await handler.Handle(new GetVehicleListQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<Vehicle>>();
            Assert.Empty(result);
        }

        

        //unit test for creating new vehicle 
        [Fact]
        public async Task AddVehicleUnitTest()
        {
            var vehicle = new Vehicle()
            {
                Name = "Renault",
                Price = 30340.21,
                ImageUrl = "https://www.renault.tn/CountriesData/Tunisia/images/cars/clio/ClioBJA_BigRange_ig_w320_h200.jpg",
                Displacement = "43B63",
                MaxSpeed = "1233",
                Length = 534.34,
                Width = 733.45,
                Height = 5.23
            };

            var handler = new AddVehicleHandler(VehicleMock.AddVehicle().Object);
            var result = await handler.Handle(new AddVehicleCommand(vehicle), CancellationToken.None);

            result.ShouldBeOfType<Vehicle>();
        }

    }
}
