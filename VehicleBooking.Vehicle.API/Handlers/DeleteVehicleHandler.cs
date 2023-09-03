using MediatR;
using VehiculeAPI.Commands;
using VehiculeAPI.Interfaces;

namespace VehiculeAPI.Handlers
{
    public class DeleteVehicleHandler : IRequestHandler<DeleteVehicleCommand, int>
    {
        private readonly IVehicleService _vehicleService;

        public DeleteVehicleHandler(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public async Task<int> Handle(DeleteVehicleCommand command, CancellationToken cancellationToken)
        {
            var vehicleToDelete = await _vehicleService.GetVehicleById(command.Id);
            if (vehicleToDelete == null)
                return default;

            return await _vehicleService.DeleteVehicle(vehicleToDelete.Id);
        }
    }

   
}
