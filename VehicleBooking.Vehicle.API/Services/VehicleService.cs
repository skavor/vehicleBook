using Microsoft.EntityFrameworkCore;
using VehiculeAPI.Data;
using VehiculeAPI.Models;
using VehiculeAPI.Interfaces;

namespace VehiculeAPI.Services
{
    public class VehicleService : IVehicleService
    {
        private VehicleApiDBContext _vehiculeDBcontext;

        public VehicleService(VehicleApiDBContext vehiculeDBcontext)
        {
            _vehiculeDBcontext = vehiculeDBcontext;
        }
        public async Task<Vehicle> AddVehicle(Vehicle vehicule)
        {
            var vehicle = await _vehiculeDBcontext.Vehicles.AddAsync(vehicule);
            await _vehiculeDBcontext.SaveChangesAsync();
            return vehicle.Entity;
          
        }

        public async Task<int> DeleteVehicle(int vehicleId)
        {
            var result = await _vehiculeDBcontext.Vehicles.FindAsync(vehicleId);
             _vehiculeDBcontext.Vehicles.Remove(result);
            return await _vehiculeDBcontext.SaveChangesAsync(); 
        }

        public async Task<List<Vehicle>> GetAllVehicles()
        {
            var vehicles = await _vehiculeDBcontext.Vehicles.ToListAsync();
            return vehicles;
            
        }

        public async Task<Vehicle> GetVehicleById(int vehicleId)
        {
            var vehicle = await _vehiculeDBcontext.Vehicles.FindAsync(vehicleId);
            return vehicle;
        }

        
        public async Task<int> UpdateVehicle(Vehicle vehicule)
        {
           
            _vehiculeDBcontext.Entry(vehicule).State = EntityState.Modified;
            return await _vehiculeDBcontext.SaveChangesAsync();
        }
    }
}
