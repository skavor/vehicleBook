using Microsoft.AspNetCore.Mvc;
using VehiculeAPI.Models;
using VehiculeAPI.Interfaces;
using MediatR;
using VehiculeAPI.Queries;
using VehiculeAPI.Commands;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text;

namespace VehiculeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediatR;
        private readonly IDistributedCache _cache;

        public VehicleController(IMediator mediatR, IDistributedCache cache)
        {
            _mediatR = mediatR;
            _cache = cache;
        }


        // This method handles an HTTP GET request to retrive all vehicles list.
        [HttpGet("AllVehicles")]
        public async Task<IActionResult> GetVehicleList()
        {
            try
            {
                string cacheKey = "VEHICLE_BOOKING_KEY";
                byte[] cachedData = await _cache.GetAsync(cacheKey);

                dynamic vehicles;
                if (cachedData != null)
                {
                    // If the data is found in the cache, encode and deserialize cached data.
                    var cachedDataString = Encoding.UTF8.GetString(cachedData);
                    vehicles = JsonSerializer.Deserialize<List<Vehicle>>(cachedDataString);
                }
                else
                {
                    // If the data is not found in the cache, then fetch data from database
                    vehicles = await _mediatR.Send(new GetVehicleListQuery());

                    // Serializing the data
                    string cachedDataString = JsonSerializer.Serialize(vehicles);
                    var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);

                    // Setting up the cache options
                    DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                        .SetSlidingExpiration(TimeSpan.FromMinutes(3));

                    // Add the data into the cache
                    await _cache.SetAsync(cacheKey, dataToCache, options);
                }
                return Ok(vehicles);
            }  catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // This method handles an HTTP GET request to retrive vehicle by Id.
        [HttpGet("{vehicleId}")]
        public async Task<IActionResult> GetVehicleById([FromRoute] int vehicleId)
        {
         
            try
            {
                var vehicle = await _mediatR.Send(new GetVehicleByIdQuery() { VehicleId = vehicleId });
                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // This method handles an HTTP Post request to add new vehicle in database.
        [HttpPost("AddVehicle")]
        public async Task<IActionResult> AddNewVehicle([FromBody] Vehicle vehicle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var restaurantCreated = await _mediatR.Send(new AddVehicleCommand(vehicle));
                    return Ok("Vehicle has been created!");
                }
                return BadRequest(new { Message = "Model Invalid" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // This method handles an HTTP PUT request to modify vehicle data for given vehicle Id.
        [HttpPut("{vehicleId}")]
        public async Task<IActionResult> UpdateVehicle([FromRoute] int vehicleId, [FromBody] Vehicle vehicule)
        {
            try
            {
                var isUpdated = await _mediatR.Send(new UpdateVehicleCommand(vehicule) { Id = vehicleId });
                if (isUpdated == 1)
                {
                    return Ok("Vehicle has been updated");
                }
                return BadRequest("Somthing went wrong! Please try again");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // This method handles an HTTP Delete request to remove vehicle data for given vehicle Id.
        [HttpDelete("{vehicleId}")]
        public async Task<IActionResult> DeleteVehicle([FromRoute] int vehicleId)
        {
           
            try
            {
                var isDeleted = await _mediatR.Send(new DeleteVehicleCommand() { Id = vehicleId });
                if(isDeleted == 1)
                {
                    return Ok("Vehicle has been deleted");
                }
                return BadRequest("Somthing went wrong! Please try again");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
