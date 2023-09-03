using VehiculeAPI.Models;

namespace VehiculeAPI.Interfaces
{
    public interface IVehicleService
    {
       

        Task<List<Vehicle>> GetAllVehicles();
        Task<Vehicle> GetVehicleById(int vehicleId);
        Task<Vehicle> AddVehicle(Vehicle vehicule);
        Task<int> DeleteVehicle(int vehicleId);
        Task<int> UpdateVehicle(Vehicle vehicule);


    }
}
