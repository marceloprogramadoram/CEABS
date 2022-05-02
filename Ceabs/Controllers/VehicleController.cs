using CEABS.Service.DTO;
using CEABS.Service.Filters;
using CEABS.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Ceabs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost]
        public async Task<ActionResult> Post(VehicleDTO vehicleDTO)
        {
            try
            {
                if (vehicleDTO == null)
                    return BadRequest();
                await _vehicleService.AddVehicle(vehicleDTO);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "erro.");
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<VehicleDTO>>> Get([FromQuery] VehicleFilter vehicleFilter)
        {
            try
            {
                var vehicleList = await _vehicleService.GetVehiclesByFilter(vehicleFilter);
                return Ok(vehicleList);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpGet("summary")]
        public async Task<ActionResult<int>> GetSummary([FromQuery] VehicleFilter vehicleFilter)
        {
            try
            {
                var total = await _vehicleService.GetStatisticVehicleByFilter(vehicleFilter);
                return Ok(new { total = total });
            }
            catch (Exception)
            {
                return StatusCode(500, "error");
            }
        }

    }
}
