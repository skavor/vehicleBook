using MediatR;
using VehiculeAPI.Commands;
using VehiculeAPI.Interfaces;
using VehiculeAPI.Models;

namespace VehiculeAPI.Handlers
{
    public class AddVehicleHandler : IRequestHandler<AddVehicleCommand, Vehicle>
    {
     
        private readonly IVehicleService _vehicleService;

        public AddVehicleHandler(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        public async Task<Vehicle> Handle(AddVehicleCommand command, CancellationToken cancellationToken)
        {
            Vehicle vehicle = new Vehicle()
            {
                Name = command.Name,
                Price = command.Price,
                ImageUrl = command.ImageUrl,
                Displacement = command.ImageUrl,
                MaxSpeed = command.MaxSpeed,
                Length = command.Length,
                Width = command.Width,
                Height = command.Height,
            };
            

            return await _vehicleService.AddVehicle(vehicle);
        }
    }
}
