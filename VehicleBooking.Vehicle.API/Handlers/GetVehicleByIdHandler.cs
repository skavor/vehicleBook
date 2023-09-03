using MediatR;
using VehiculeAPI.Interfaces;
using VehiculeAPI.Models;
using VehiculeAPI.Queries;

namespace VehiculeAPI.Handlers
{
    public class GetVehicleByIdHandler : IRequestHandler<GetVehicleByIdQuery, Vehicle>
    {
        private readonly IVehicleService _vehicleService;

        public GetVehicleByIdHandler(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public async Task<Vehicle> Handle(GetVehicleByIdQuery query, CancellationToken cancellationToken)
        {
            return await _vehicleService.GetVehicleById(query.VehicleId);
        }
    }
}
