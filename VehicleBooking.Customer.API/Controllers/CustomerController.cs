using CustomersAPI.Commands;
using CustomersAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;



namespace CustomersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        
        private readonly IMediator _mediatR;
        public CustomerController(IMediator mediatR)
        {
            
            _mediatR = mediatR;
        }

        // This method handles an HTTP Post request to add vehicle to new customer.
        [HttpPost("AddVehicleToCustomer")]
        public async Task<IActionResult> AddVehicleToCustomer([FromBody] Customer customer)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    
                    var result = await _mediatR.Send(new AddVehicleToCustomerCommand(customer));
                    if (result != null)
                    {
                        return Ok("Vehicle is added to customer");
                    }
                    return BadRequest("Somthing went wrong! Please try again");
                }
                return BadRequest("Model Invalid");

            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
