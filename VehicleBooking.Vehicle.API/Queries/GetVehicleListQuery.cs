using MediatR;
using VehiculeAPI.Models;

namespace VehiculeAPI.Queries
{
    public class GetVehicleListQuery: IRequest<List<Vehicle>>
    {
    }
}
