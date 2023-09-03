using MediatR;

namespace VehiculeAPI.Commands
{
    public class DeleteVehicleCommand  : IRequest<int>
    {
        public int Id { get; set; }
    }

}
