using MediatR;
using VehiculeAPI.Interfaces;
using VehiculeAPI.Models;
using VehiculeAPI.Queries;

namespace VehiculeAPI.Handlers
{
    public class GetVehiclesListHandler : IRequestHandler<GetVehicleListQuery, List<Vehicle>>
    {
        private readonly IVehicleService _vehicleService;

        public GetVehiclesListHandler(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public async Task<List<Vehicle>> Handle(GetVehicleListQuery query, CancellationToken cancellationToken)
        {
            return await _vehicleService.GetAllVehicles();
        }
    }
    
}
