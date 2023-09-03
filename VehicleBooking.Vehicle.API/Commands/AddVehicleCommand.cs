using MediatR;
using VehiculeAPI.Models;

namespace VehiculeAPI.Commands
{
    public class AddVehicleCommand : IRequest<Vehicle>
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? ImageUrl { get; set; }

        public string? Displacement { get; set; }

        public string? MaxSpeed { get; set; }
        public double Length { get; set; }

        public double Width { get; set; }
        public double Height { get; set; }
        public AddVehicleCommand(Vehicle vehicle)
        {
            Name = vehicle.Name;
            Price = vehicle.Price;
            ImageUrl = vehicle.ImageUrl;
            Displacement = vehicle.ImageUrl;
            MaxSpeed = vehicle.MaxSpeed;
            Length = vehicle.Length;
            Width = vehicle.Width;
            Height = vehicle.Height;

        }
    }
}
