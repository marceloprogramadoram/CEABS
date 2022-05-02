using CEABS.Service.DTO;
using CEABS.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Ceabs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelCarController : ControllerBase
    {
        private readonly IModelCarService _serviceModelCar;

        public ModelCarController(IModelCarService serviceModelCar)
        {
            _serviceModelCar = serviceModelCar;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Post(ModelCarDTO modelCarDTO)
        {
            try
            {
                if (modelCarDTO is null)
                    return BadRequest();
                await _serviceModelCar.AddModel(modelCarDTO);
                return Ok(modelCarDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(int id)
        {
            try
            {
                await _serviceModelCar.UpdateModel(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpPut("remove/{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            try
            {
                await _serviceModelCar.DeleteModel(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }


        [HttpGet("all")]
        public async Task<ActionResult<List<ModelCarDTO>>> GetModelCar()
        {
            try
            {
                return await _serviceModelCar.GetAllModelCars();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpGet("byname/{modelName}")]
        public async Task<ActionResult<ModelCarDTO>> GetModelCarByName(string modelName)
        {
            try
            {
                return await _serviceModelCar.GetModelCarByName(modelName);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpGet("code/{key}")]
        public async Task<ActionResult<ModelCarDTO>> GetModelCarById(int key)
        {
            try
            {
                return await _serviceModelCar.GetModelCarById(key);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }




    }
}
