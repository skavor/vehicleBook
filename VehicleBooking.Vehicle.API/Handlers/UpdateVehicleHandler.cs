using MediatR;
using VehiculeAPI.Commands;
using VehiculeAPI.Interfaces;

namespace VehiculeAPI.Handlers
{
    public class UpdateVehicleHandler : IRequestHandler<UpdateVehicleCommand, int>
    {
        private readonly IVehicleService _vehicleService;

        public UpdateVehicleHandler(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        public async Task<int> Handle(UpdateVehicleCommand command, CancellationToken cancellationToken)
        {
            var vehiculeToUpdate = await _vehicleService.GetVehicleById(command.Id);
            if (vehiculeToUpdate == null)
                return default;

            vehiculeToUpdate.ImageUrl = command.ImageUrl;
            vehiculeToUpdate.Height = command.Height;
            vehiculeToUpdate.Length = command.Length;
            vehiculeToUpdate.MaxSpeed = command.MaxSpeed;
            vehiculeToUpdate.Price = command.Price;
            vehiculeToUpdate.Name = command.Name;
            vehiculeToUpdate.Width = command.Width;

            return await _vehicleService.UpdateVehicle(vehiculeToUpdate);
        }
    }

   
}
