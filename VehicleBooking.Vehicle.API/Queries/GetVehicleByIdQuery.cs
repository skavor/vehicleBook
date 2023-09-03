using MediatR;
using VehiculeAPI.Models;

namespace VehiculeAPI.Queries
{
    public class GetVehicleByIdQuery : IRequest<Vehicle>
    {
        public int VehicleId { get; set; }
    }
}
